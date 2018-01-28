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
        if(StatManager.Instance.cash >= 5)
        {
            if (minionType == 1)
            {
                StatManager.Instance.cash -= 5;
                StatManager.Instance.thugs++;
                //This is here for debugging purposes will be removed
                // mtController.totalMoney -= 5;
                //StatManager.Instance.terrorizeZone(1, 500);
                //Debug.Log(StatManager.Instance.hysteria);
            }
        }
        if(StatManager.Instance.cash >= 15)
        {
           if (minionType == 2)
            {
                StatManager.Instance.cash -= 15;
                StatManager.Instance.robbers++;
                // mtController.totalMoney -= 15;
            }
        }
        if(StatManager.Instance.cash >= 50)
        {
            if (minionType == 3)
            {
                StatManager.Instance.cash -= 50;
                StatManager.Instance.pols++;
                //mtController.totalMoney -= 50;
            }
        }
        
    }
}
