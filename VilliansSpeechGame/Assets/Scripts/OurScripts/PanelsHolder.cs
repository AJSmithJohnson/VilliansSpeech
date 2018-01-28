using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHolder : MonoBehaviour
{

    public GameObject newsPanel;
    public GameObject hentchmenPanel;
    public GameObject cityPanel;
    public GameObject fuel;
    public GameObject spaceSuit;
    public GameObject rocket;
    public GameObject villiansLair;
    public GameObject gotFuel;
    public GameObject gotMoney;
    public GameObject gotSuit;
    public GameObject gotRocket;
    public GameObject bluffFail;
    public GameObject makePay;
    public GameObject desBuilding;
    public GameObject napMayor;
    public GameObject poison;
    public GameObject evilPlanPanel;

    public GameObject rocketImg;
    public GameObject flagImg;
    public GameObject spaceSuitImg;
    public GameObject moneyImg;
    void start()
    {
        
    }

    


    public void showDesBuilding()
    {
        //evilPlanPanel.SetActive(true);
        cityPanel.SetActive(false);
        desBuilding.SetActive(true);
        cityPanel.SetActive(false);

    }

    public void hideDesBuilding()
    {
        //evilPlanPanel.SetActive(false);
        desBuilding.SetActive(false);
    }
    public void showNapMayor()
    {
        cityPanel.SetActive(false);
        // evilPlanPanel.SetActive(true);
        napMayor.SetActive(true);

    }

    public void hideNapMayor()
    {
       // evilPlanPanel.SetActive(false);
        napMayor.SetActive(false);
    }
    public void showPoison()
    {
        cityPanel.SetActive(false);
        // evilPlanPanel.SetActive(true);
        poison.SetActive(true);

    }

    public void hidePoison()
    {
       // evilPlanPanel.SetActive(false);
        poison.SetActive(false);
    }




    public void showGotFuel()
    {
        flagImg.SetActive(true);
        gotFuel.SetActive(true);

    }

    public void hideGotFuel()
    {

        gotFuel.SetActive(false);
    }

                      
    public void showGotMoney()
    {
        moneyImg.SetActive(true);
        gotMoney.SetActive(true);

    }                  
                       
    public void hideGotMoney()
    {
        gotMoney.SetActive(false);

    }

    public void showGotSuit()
    {
        spaceSuitImg.SetActive(true);
        gotSuit.SetActive(true);
    }                
                     
    public void hideGotSuit()
    {

        gotSuit.SetActive(false);
    }

    public void showGotRocket()
    {
       rocketImg.SetActive(true);
        gotRocket.SetActive(true);

    }                 
                      
    public void hideGotRocket()
    {

        gotRocket.SetActive(false);
    }

    public void showBluffFail()
    {
        bluffFail.SetActive(true);

    }               
                    
    public void hideBluffFail()
    {
        bluffFail.SetActive(false);

    }

    public void showMakePay()
    {
        makePay.SetActive(true);

    }              
                   
    public void hideMakePay()
    {
        makePay.SetActive(false);

    }

    public void showVilliansLairPanel()
    {
        villiansLair.SetActive(true);
    }
    public void hideVilliansLairPanel()
    {
        villiansLair.SetActive(false);
    }
    public void ShowNewsPanel()
    {
        newsPanel.SetActive(true);
    }
    public void HideNewsPanel()
    {
        newsPanel.SetActive(false);
    }
    public void ShowhentchmenPanel()
    {
        hentchmenPanel.SetActive(true); 
    }               
    public void HidehentchmenPanel()
    {
        hentchmenPanel.SetActive(false);
    }              
    public void ShowcityPanel()
    {
        cityPanel.SetActive(true);
    }              
    public void HidecityPanel()
    {
        cityPanel.SetActive(false);
    }

    public void CheckAndHidePlans()
    {
        if (StatManager.Instance.hasFuel)
        {
            fuel.SetActive(false);
        }
        if (StatManager.Instance.hasRocket)
        {
            rocket.SetActive(false);
        }
        if (StatManager.Instance.hasSpacesuit)
        {
            spaceSuit.SetActive(false);
        }
    }


    public void CheckAndRevealPlans()
    {
        if (!StatManager.Instance.hasFuel)
        {
            fuel.SetActive(true);
        }
        if (!StatManager.Instance.hasRocket)
        {
            rocket.SetActive(true);
        }
        if (!StatManager.Instance.hasSpacesuit)
        {
            spaceSuit.SetActive(true);
        }
    }

}
