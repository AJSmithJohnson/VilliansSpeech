using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StatManager.Instance.cash = 100;
        StatManager.Instance.hasFuel = false;
        StatManager.Instance.hasRocket = false;
        StatManager.Instance.hasSpacesuit = false;
        StatManager.Instance.robbers = 0;
        StatManager.Instance.thugs = 0;
        StatManager.Instance.pols= 0;
        StatManager.Instance.policeProgress = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
