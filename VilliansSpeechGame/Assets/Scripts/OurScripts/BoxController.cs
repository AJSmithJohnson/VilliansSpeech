using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxController : MonoBehaviour {
    public int catagory;
    public int value = -1;
    public Text text;
   

	// Use this for initialization
	void Start () {

        text.text = "<DRAG HERE>";
	}
	
	// Update is called once per frame
	void Update () {
        //print("catagory" + catagory + " value   " + value);
    }
}
