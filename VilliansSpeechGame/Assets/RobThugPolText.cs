using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobThugPolText : MonoBehaviour {

    public Text thisObjectsText;
	// Use this for initialization
	void Start () {
        thisObjectsText.GetComponentInParent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        thisObjectsText.text = ("Robbers:" + StatManager.Instance.robbers.ToString() + "\n Thugs:" + StatManager.Instance.thugs.ToString() + "\n Politicians:" + StatManager.Instance.pols.ToString() );
	}
}
