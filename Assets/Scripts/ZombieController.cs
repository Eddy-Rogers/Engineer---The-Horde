using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {

    public List<Character> zombieList;
    GameObject player;

    float timer = 0;

    bool canAttack = true;

    int excludeEnemy = ~((1 << 9) | (1 << 2));

    // Use this for initialization
    void Start () {
        GameObject[] allEnemies = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
        zombieList = new List<Character>();
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject z in allEnemies)
        {
            zombieList.Add(z.GetComponent<Character>());
        }
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer > 1)
        {
            foreach (Character c in zombieList)
            {
               if(c != null)
                {
                    if (c.KnowsPlayerLocation())
                    {
                        LineOfSight(c.gameObject);
                        c.ZombieMovement((player.transform.position - c.transform.position).normalized);
                    }
                    else
                    {
                        c.ZombieMovement(Vector2.zero);
                    }
                }
            }
            timer--;
        }
        else
        {
            foreach (Character c in zombieList)
            {
                if (c != null)
                {
                    if (c.KnowsPlayerLocation())
                    {
                        c.ZombieMovement((player.transform.position - c.transform.position).normalized);
                    }
                    else
                    {
                        c.ZombieMovement(Vector2.zero);
                    }
                }
               
            }
        }
	}

    private void LineOfSight(GameObject other)
    {
        Vector2 rayCastDir = transform.position - other.transform.position;
        //Debug.DrawRay(other.transform.position, rayCastDir, Color.red);
        RaycastHit2D hit = Physics2D.Linecast(other.transform.position, player.transform.position, excludeEnemy);
        //Debug.Log("ENTER: " + hit.transform.gameObject.name);
        if (hit.transform.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Character>().SetKnowsPlayerLocation(true);
        }
        else
        {
            other.GetComponent<Character>().SetKnowsPlayerLocation(false);
        }
    }

    IEnumerator PollLineOfSight(GameObject other)
    {
        Character c = other.GetComponent<Character>();
        while (c.KnowsPlayerLocation())
        {
            LineOfSight(other);
            yield return new WaitForSeconds(1f);
        }
    }
}
