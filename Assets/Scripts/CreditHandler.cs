using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditHandler : MonoBehaviour {

    SceneSwitcher switcher;

	// Use this for initialization
	void Awake () {
        switcher = GetComponent<SceneSwitcher>();
        StartCoroutine(CreditDelay());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator CreditDelay()
    {
        Debug.Log("Entered");
        yield return new WaitForSeconds(5f);
        switcher.SwitchScene("Menu");
    }
}
