using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsHolder : MonoBehaviour
{

    public GameObject newsPanel;
    public GameObject hentchmenPanel;
    public GameObject cityPanel;
    

    void start()
    {
        
    }
    public void showNewsPanel()
    {
        newsPanel.SetActive(true);
    }
    public void hideNewsPanel()
    {
        newsPanel.SetActive(false);
    }
    public void showhentchmenPanel()
    {
        hentchmenPanel.SetActive(true); 
    }               
    public void hidehentchmenPanel()
    {
        hentchmenPanel.SetActive(false);
    }              
    public void showcityPanel()
    {
        cityPanel.SetActive(true);
    }              
    public void hidecityPanel()
    {
        cityPanel.SetActive(false);
    }
   
}
