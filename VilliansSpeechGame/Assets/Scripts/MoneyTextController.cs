using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MoneyTextController : MonoBehaviour {
    public float totalMoney;
    public Text moneyText;
	// Use this for initialization
	void Start () {

        totalMoney = StatManager.Instance.cash;

        moneyText = GetComponentInParent<Text>();
        moneyText.text =  totalMoney.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        moneyText.text = ("$" + StatManager.Instance.cash.ToString()); 
    }
}
