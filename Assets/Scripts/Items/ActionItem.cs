using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionItem : MonoBehaviour {

    //Sprite of the object
    SpriteRenderer rend;

    //Data associated with this object
    public ItemData itemData;

    public Sprite explosionSprite;

    GameObject gameManager;

    AudioSource audioData;

    public GameObject explosion;

    // Use this for initialization
    void Start () {
		
	}

    private void Awake()
    {
        audioData = GetComponent<AudioSource>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = itemData.icon;
        Debug.Log(itemData.GetType().Name);
        switch(itemData.GetType().Name) {
            case "ExplosiveItemData":
                Debug.Log("This is an explosive item");
                StartCoroutine(ExplosiveItemTimer((ExplosiveItemData)itemData));

                break;
        }
    }

    IEnumerator ExplosiveItemTimer(ExplosiveItemData explosive)
    {
        yield return new WaitForSeconds(explosive.explosionTimer);
        StartCoroutine(Explode(explosive));
    }

    IEnumerator Explode(ExplosiveItemData explosive)
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosive.explosionRadius);

        audioData.Play(0);

        for(int i = 0; i < hits.Length; i++)
        {
            if(hits[i].CompareTag("Enemy"))
            {
                Destroy(hits[i].gameObject);
                gameManager.GetComponent<ZombieController>().zombieList.Remove(gameObject.GetComponent<Character>());
            }
        }

        /*
        rend.sprite = explosionSprite;
        Color c = Color.red;
        c.a = 100f / 255f;
        rend.color = c;
        transform.localScale = new Vector3(explosive.explosionRadius * 2, explosive.explosionRadius * 2, explosive.explosionRadius * 2);
        */



        List<ParticleSystem> p = new List<ParticleSystem>();
        GameObject particle = Instantiate(explosion, transform);

        p.AddRange(particle.GetComponentsInChildren<ParticleSystem>());
        p.Add(particle.GetComponent<ParticleSystem>());

        foreach(ParticleSystem s in p)
        {
            s.transform.position = transform.position;
            s.Play();
        }

        Color transparent = new Color(0, 0, 0, 0);

        rend.color = transparent;

        yield return new WaitForSeconds(4);

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    //Setter method for the item data of this object
    public void SetItemData(ItemData toSet)
    {
        itemData = toSet;
    }
}
