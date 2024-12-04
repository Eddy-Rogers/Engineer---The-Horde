using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    AudioSource audioData;

	// Use this for initialization
	void Awake () {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
