using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour {

    PlayerManager player;

    bool canAttack;

    int attackDamage = 5;

	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerManager>();
        canAttack = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAttackTrue()
    {
        canAttack = true;
    }

    public void SetAttackFalse()
    {
        canAttack = false;
    }

    public IEnumerator AttackTimer()
    {
        while(canAttack)
        {
            player.TakeDamage(attackDamage);
            yield return new WaitForSeconds(3);
        }
    }


}
