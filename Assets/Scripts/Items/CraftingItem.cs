using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingItem : MonoBehaviour {

    //Sprite of the object
    SpriteRenderer rend;

    //Data associated with this object
    public ItemData itemData;

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

    //Setter method for the item data of this object
    public void SetItemData(ItemData toSet)
    {
        itemData = toSet;
    }
}
