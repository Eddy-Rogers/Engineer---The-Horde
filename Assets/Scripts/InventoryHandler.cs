using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour {

    //Singleton reference to the player's inventory
    public static InventoryHandler instance;

    public ItemData diesel;
    public ItemData fertilizer;
    public ItemData fertilizerBomb;

    GameObject bombCount;

    void Awake()
    {
        instance = this;
        bombCount = GameObject.FindGameObjectWithTag("BombCount");
    }

    //Dictionary to keep track of the amount of items a player has
    Dictionary<ItemData, int> inventory;

    //Adds an item to the dictionary keeping track of the player's items
    public void AddItem(ItemData toAdd, int amount = 1)
    {
        if (inventory == null)
        {
            inventory = new Dictionary<ItemData, int>();
        }
        if (inventory.ContainsKey(toAdd))
        {
            inventory[toAdd] += amount;
        }
        else
        {
            inventory.Add(toAdd, amount);
        }
        if(inventory.ContainsKey(diesel) && inventory.ContainsKey(fertilizer))
        {
            if (inventory[diesel] > 0 && inventory[fertilizer] > 0)
            {
                Debug.Log("Created");
                if (inventory.ContainsKey(fertilizerBomb))
                {
                    inventory[fertilizerBomb]++;
                }
                else
                {
                    inventory.Add(fertilizerBomb, 1);
                }
                inventory[diesel]--; inventory[fertilizer]--;
                bombCount.GetComponent<Text>().text = "x" + inventory[fertilizerBomb];
            }
        }
    }

    public int ItemCount(ItemData toCheck)
    {
        if (inventory.ContainsKey(toCheck)) { return inventory[toCheck]; }
        else { return 0; }
    }

    public bool HasItem(ItemData toCheck, int amount = 1)
    {
        if (inventory.ContainsKey(toCheck) && inventory[toCheck] >= amount)
        {
            return true;
        }
        return false;
    }

    public void RemoveItem(ItemData toRemove, int amount = 1)
    {
        if (inventory.ContainsKey(toRemove))
        {
            inventory[toRemove] -= amount;
        }
        if(toRemove.Equals(fertilizerBomb))
        {
            bombCount.GetComponent<Text>().text = "x" + inventory[fertilizerBomb];
        }
    }

    public void UpdateUI()
    {
        bombCount.GetComponent<Text>().text = "x" + inventory[fertilizerBomb];
    }

    private void Start()
    {
        if (inventory == null)
        {
            inventory = new Dictionary<ItemData, int>();
        }
    }

}
