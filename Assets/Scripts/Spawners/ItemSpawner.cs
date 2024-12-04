using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

    public GameObject[] itemPrefabs;
    List<GameObject> items;

	// Use this for initialization
	void Start () {
        items = new List<GameObject>();
		for(int i = 0; i < 10; i++)
        {
            float spawnX = Random.Range(-49f, 49f);
            float spawnY = Random.Range(23, -75f);
            items.Add(Instantiate<GameObject>(itemPrefabs[0], new Vector2(spawnX, spawnY), new Quaternion(0, 0, 0, 0)));
        }
        for (int i = 0; i < 10; i++)
        {
            float spawnX = Random.Range(-49f, 49f);
            float spawnY = Random.Range(23f, -75f);
            items.Add(Instantiate<GameObject>(itemPrefabs[1], new Vector2(spawnX, spawnY), new Quaternion(0, 0, 0, 0)));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
