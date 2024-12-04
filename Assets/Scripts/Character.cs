using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType { Player, Zombie }

public class Character : MonoBehaviour {

    Animator anim;

    Vector2 movementInput;
    public CharacterType charType;
    public float speed = 3f;

    bool knowsPlayerLocation;

	// Use this for initialization
	void Start () {
        knowsPlayerLocation = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(movementInput != Vector2.zero)
        {
            transform.position += (Vector3)movementInput * speed * Time.deltaTime;
            anim.SetFloat("MoveHorizontal", movementInput.x);
        }
	}

    public void PlayerMovement(Vector2 movement) {
        movementInput = movement;
    }

    public void ZombieMovement(Vector2 movement) {
        movementInput = movement;
    }

    public void SetKnowsPlayerLocation(bool input)
    {
        knowsPlayerLocation = input;
    }

    public bool KnowsPlayerLocation()
    {
        return knowsPlayerLocation;
    }

}
