using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public bool isLoad;

	// Use this for initialization
	void Start () {
        isLoad = false;
        DontDestroyOnLoad(gameObject);
	}

    public void SetLoad(bool loaded)
    {
        isLoad = loaded;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
