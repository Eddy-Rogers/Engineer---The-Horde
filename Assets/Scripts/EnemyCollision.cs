using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    ZombieController cont;

    AudioSource audioData;

    int excludeEnemy = ~((1 << 9) | (1 << 2));

    // Use this for initialization
    void Awake () {
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.transform.gameObject.name);
        GameObject otherObject = other.transform.gameObject;
        if (otherObject.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("AttackCollider"))
            {
                ZombieManager zed = otherObject.GetComponent<ZombieManager>();
                zed.SetAttackTrue();
                zed.StartCoroutine("AttackTimer");
            }
            LineOfSight(other.transform.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject otherObject = other.transform.gameObject;
        if (otherObject.CompareTag("Enemy") && gameObject.CompareTag("AttackCollider"))
        {
            ZombieManager zed = otherObject.GetComponent<ZombieManager>();
            if(zed != null)
            {
                zed.SetAttackFalse();
            }
        }
    }

    private void LineOfSight(GameObject other)
    {
        Vector2 rayCastDir = transform.position - other.transform.position;
        Debug.DrawRay(other.transform.position, rayCastDir, Color.red);
        RaycastHit2D hit = Physics2D.Linecast(other.transform.position, transform.parent.position, excludeEnemy);
        Debug.Log("ENTER: " + hit.transform.gameObject.name);
        if (hit.transform.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Character>().SetKnowsPlayerLocation(true);
            audioData.Play(0);
        }
        else
        {
            other.GetComponent<Character>().SetKnowsPlayerLocation(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, 0.2f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gameObject.transform.position, 0.2f);
    }
}
