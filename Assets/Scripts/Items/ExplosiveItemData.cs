using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Explosive Item", menuName = "ExplosiveItem", order = 1)]
public class ExplosiveItemData : ItemData {

    public float explosionRadius;
    public float explosionPower;

    public float explosionTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
