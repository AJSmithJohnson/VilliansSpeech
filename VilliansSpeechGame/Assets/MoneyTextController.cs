using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoneyTextController : MonoBehaviour {
    public int totalMoney;
    public Text moneyText;
	// Use this for initialization
	void Start () {

        totalMoney = 50;

        moneyText = GetComponentInParent<Text>();
        moneyText.text =  totalMoney.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = totalMoney.ToString();
    }
}
