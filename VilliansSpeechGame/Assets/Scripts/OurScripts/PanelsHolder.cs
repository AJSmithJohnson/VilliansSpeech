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
    void start()
    {
        
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
