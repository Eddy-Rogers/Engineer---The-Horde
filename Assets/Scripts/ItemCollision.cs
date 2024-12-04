using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {

    AudioSource audioData;

    // Use this for initialization
    void Awake () {
        audioData = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the object we have collided with is a "Pickup Item"
        if (other.transform.gameObject.CompareTag("PickupItem"))
        {
            //Add the object to the player's inventory
            InventoryHandler.instance.AddItem(other.transform.gameObject.GetComponent<CraftingItem>().itemData);

            audioData.Play(0);

            //Destory the object
            GameObject.Destroy(other.transform.gameObject);

        }
    }
}
