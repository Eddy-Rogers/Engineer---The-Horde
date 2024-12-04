using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

    //Singleton reference to the Player Manager
    public static PlayerManager instance;
    public GameObject player;

    PlayerController playerController;

    Slider healthBar;

     int health = 100;

	// Use this for initialization
	void Start () {
        playerController = player.GetComponent<PlayerController>();
	}

    void Awake()
    {
        instance = this;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public int getHealth()
    {
        return health;
    }

    public void TakeDamage(int damageToTake)
    {

        playerController.PlayHitEffect();

        health -= damageToTake;
        healthBar.value = ((float)health / 100f);

        if(health <= 0)
        {
            SceneManager.LoadScene("Credits");
        }
    }
}
