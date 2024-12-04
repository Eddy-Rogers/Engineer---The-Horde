using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

    public GameObject[] zombiePrefabs;
    ZombieController manager;

    // Use this for initialization
    void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ZombieController>();
        for (int i = 0; i < 30; i++)
        {
            float spawnX = Random.Range(-49f, 49f);
            float spawnY = Random.Range(23f, -75f);

            //Spawn Protection
            while (spawnX < 5 && spawnX > -5 && spawnY < 5 && spawnY > -5)
            {
                spawnX = Random.Range(-49f, 49f);
                spawnY = Random.Range(23f, -75f);
            }

            manager.zombieList.Add(Instantiate<GameObject>(zombiePrefabs[0], new Vector2(spawnX, spawnY), new Quaternion(0, 0, 0, 0)).GetComponent<Character>());
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
