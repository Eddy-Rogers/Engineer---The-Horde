using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

[System.Serializable]
public struct SaveDataContainer
{
    public float[,] fertilizerList;
    public float[,] dieselList;
    public float[,] zombieList;
    public PlayerInformation player;
}

[System.Serializable]
public struct PlayerInformation
{
    public float health;

    public float[] transform;

    public int bombNumber;
    public int fertilizerNumber;
    public int dieselNumber;
}

public class SaveScene : MonoBehaviour {

    public ItemData fert;
    public ItemData diesel;
    public ItemData bomb;

    GameObject manager;
    GameObject player;

	// Use this for initialization
	void Start () {
        manager = GameObject.FindGameObjectWithTag("GameManager");
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save()
    {
        int dieselCount = 0;
        int fertilizerCount = 0;
        GameObject[] pickupItems = GameObject.FindGameObjectsWithTag("PickupItem");
        for(int i = 0; i < pickupItems.Length; i++)
        {
            if(pickupItems[i].GetComponent<CraftingItem>().itemData.Equals(fert))
            {
                fertilizerCount++;
            }
            else
            {
                dieselCount++;
            }
        }

        float[,] fertilizerList = new float[fertilizerCount, 2];
        float[,] dieselList = new float[dieselCount, 2];

        for (int i = 0, j = 0, k = 0; i < pickupItems.Length; i++)
        {
            if (pickupItems[i].GetComponent<CraftingItem>().itemData.Equals(fert))
            {
                fertilizerList[j, 0] = pickupItems[i].transform.position.x;
                fertilizerList[j, 1] = pickupItems[i].transform.position.y;
                j++;
            }
            else
            {
                dieselList[j, 0] = pickupItems[i].transform.position.x;
                dieselList[j, 1] = pickupItems[i].transform.position.y;
                k++;
            }
        }


        

        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");

        float[,] zombieList = new float[zombies.Length, 2];

        for (int i = 0; i < zombies.Length; i++)
        {
            zombieList[i, 0] = zombies[i].transform.position.x;
            zombieList[i, 1] = zombies[i].transform.position.y;
            Debug.Log(zombieList[i, 0]);
        }

        SaveDataContainer saveInfo;

        saveInfo.fertilizerList = fertilizerList;
        saveInfo.dieselList = dieselList;
        saveInfo.zombieList = zombieList;

        PlayerInformation playerInfo;

        playerInfo.bombNumber = manager.GetComponent<InventoryHandler>().ItemCount(bomb);
        playerInfo.fertilizerNumber = manager.GetComponent<InventoryHandler>().ItemCount(fert);
        playerInfo.dieselNumber = manager.GetComponent<InventoryHandler>().ItemCount(diesel);

        playerInfo.transform = new float[] { player.transform.position.x, player.transform.position.y };

        playerInfo.health = manager.GetComponent<PlayerManager>().getHealth();

        saveInfo.player = playerInfo;

        string serializedInfo = JsonUtility.ToJson(saveInfo, true);

        using (StreamWriter s = File.CreateText(Application.persistentDataPath + "/save.txt"))
        {
            s.Write(serializedInfo);
        }
    }
}
