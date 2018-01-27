using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireController : MonoBehaviour {
    public MoneyTextController mtController;
    public int minionType;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpendMoney()
    {
        if(minionType == 1)
        {
            mtController.totalMoney -= 5;
        }
        else if (minionType == 2)
        {
            mtController.totalMoney -= 15;
        }
        else if (minionType == 3)
        {
            mtController.totalMoney -= 50;
        }
    }
}
