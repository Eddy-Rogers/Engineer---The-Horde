using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour {

    public ItemData data;
    SpriteRenderer rend;

	// Use this for initialization
	void Start () {
		
	}

    void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update () {	
        
	}

    public void SetItemData(ItemData newData)
    {
        data = newData;
    }
}
