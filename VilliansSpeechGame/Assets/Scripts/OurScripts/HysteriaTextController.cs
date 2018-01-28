using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HysteriaTextController : MonoBehaviour {
    public Text hysteriaText;
    public int zoneNum;
    // Use this for initialization
    void Start () {
        hysteriaText = GetComponentInParent<Text>();
    }

    // Update is called once per frame
    void Update() {
        hysteriaText.text = (StatManager.Instance.zones[zoneNum].hysteria.ToString() + "%");
	}
}
