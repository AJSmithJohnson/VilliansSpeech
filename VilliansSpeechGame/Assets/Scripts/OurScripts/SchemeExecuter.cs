using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SchemeExecuter : MonoBehaviour {

    Result result;
    public BoxController methodBox;
    public BoxController demandBox;
    public BoxController threatBox;
    public BoxController locationBox;
    public BoxController bluffBox;
    public PanelsHolder panelsHolder;

    public GameObject suit;
    public GameObject flag;
    public GameObject rocket;

    public GameObject winScreen;
    public GameObject riotScreen;
    public GameObject arrestScreen;

    public Text hyst;
    public Text arst;

    public Result calculateSuccess(Plan plan, DistributionMethod dist, bool bluff = false)
    {
        Debug.Log(plan.targetZone);
        defaultResults(dist.evidenceProduced);
        
        if ((StatManager.Instance.hysteria + StatManager.Instance.pols) * dist.successMod >= plan.hysteriaNeeded)
        {//success
            switch (demandBox.value)
            {
                case 1:
                    StatManager.Instance.terrorizeZone(plan.targetZone, plan.hysteriaProvided);
                    StatManager.Instance.calcMoney();
                    StatManager.Instance.BigMoney();
                    panelsHolder.showGotMoney();
                    calculateLoseState();
                    Debug.Log("WOrking Win Demand");
                    return Result.gotMoney;
                case 2:
                    StatManager.Instance.calcMoney();
                    StatManager.Instance.hasFuel = true;
                    panelsHolder.showGotFuel();
                    calculateLoseState();
                    return Result.gotFlag;
                case 3:
                    StatManager.Instance.calcMoney();
                    panelsHolder.showGotSuit();
                    StatManager.Instance.hasSpacesuit = true;
                    calculateLoseState();
                    return Result.gotSpacesuit;
                case 4:
                    StatManager.Instance.calcMoney();
                    panelsHolder.showGotRocket();
                    StatManager.Instance.hasRocket = true;
                    calculateLoseState();
                    return Result.gotRocket;
                default:
                    return new Result();                    
            }
        }else if (bluff)
        {//bluff failed
            panelsHolder.showBluffFail();
            Debug.Log("WOrking Loose Demand");
            calculateLoseState();
            StatManager.Instance.relaxZone(plan.targetZone, plan.hysteriaProvided);
            return Result.bluffFail;
        }
        panelsHolder.showMakePay();
        Debug.Log("WOrking raiseHysteria");
        calculateLoseState();
        StatManager.Instance.terrorizeZone(plan.targetZone, plan.hysteriaProvided);
        StatManager.Instance.policeProgress += (StatManager.Instance.thugs * 20 + StatManager.Instance.robbers * 10 - StatManager.Instance.pols * 10);

        switch (threatBox.value)
        {
            case 1:
                return Result.kidnap;
            case 2:
                return Result.poison;
            case 3:
                return Result.demolition;
            default:
                return new Result();
        }

        
    }

    public void generatePlan() {
        Plan plan = new Plan();
        DistributionMethod dist = new DistributionMethod();
        bool bluff = (bluffBox.value == 1);

        dist.successMod = methodBox.value;
        dist.evidenceProduced = (methodBox.value - 1) * 10;

        plan.hysteriaNeeded = (demandBox.value - 1) * 100;
        if (!bluff)
        {
            switch (threatBox.value)
            {
                //kidnapping
                case 1:

                   panelsHolder.showNapMayor();
                    plan.hysteriaProvided = 25;


                    break;
                //poison
                case 2:
                    panelsHolder.showPoison();
                    plan.hysteriaProvided = 50;

                    break;
                //demolitions
                case 3:
                    panelsHolder.showDesBuilding();
                    plan.hysteriaProvided = 100;

                    break;
            }
        }
        

        print("lbox " + locationBox.value);
        plan.targetZone = locationBox.value - 1;
        calculateSuccess(plan, dist, bluff);
        // print("money " + StatManager.Instance.cash);
        //print("hysteria " + StatManager.Instance.hysteria);
        //print("evidence " + StatManager.Instance.policeProgress);
        //print(calculateSuccess(plan, dist, bluff));
    }

    public void calculateLoseState()
    {
        if (rocket.activeInHierarchy && flag.activeInHierarchy && suit.activeInHierarchy)
        {
            GameObject.FindObjectOfType<AudioController>().playAudio(6);
            winScreen.SetActive(true);
        }
        if (StatManager.Instance.hysteria > 100)
        {
            //lose due to rioting

            //Create new panel

            //Two buttons to start over

            //Or to Exit the game
            GameObject.FindObjectOfType<AudioController>().playAudio(2);
            riotScreen.SetActive(true);
        }
        if(StatManager.Instance.policeProgress > 100)
        {
            //lose due to police activity
            GameObject.FindObjectOfType<AudioController>().playAudio(0);
            arrestScreen.SetActive(true);
        }
    }

    void defaultResults(int evidence)
    {
        StatManager.Instance.policeProgress += evidence;
        StatManager.Instance.calcMoney();
    }

    public void updateText()
    {
        hyst.text = StatManager.Instance.hysteria.ToString();
        arst.text = StatManager.Instance.policeProgress.ToString();
    }

    public void reload()
    {
        StatManager.Instance.Reset();
        SceneManager.LoadScene(1);
    }

}
