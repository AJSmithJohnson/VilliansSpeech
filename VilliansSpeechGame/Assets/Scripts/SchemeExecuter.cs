using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchemeExecuter : MonoBehaviour {

    Result result;
    public BoxController methodBox;
    public BoxController demandBox;
    public BoxController threatBox;
    public BoxController locationBox;
    public BoxController bluffBox;

	public Result calculateSuccess(Plan plan, DistributionMethod dist, bool bluff = false)
    {
        defaultResults(dist.evidenceProduced);

        if ((StatManager.Instance.hysteria + StatManager.Instance.pols) * dist.successMod >= plan.hysteriaNeeded)
        {//success
            switch (demandBox.value)
            {
                case 1:
                    return Result.gotMoney;
                case 2:
                    return Result.gotFlag;
                case 3:
                    return Result.gotSpacesuit;
                case 4:
                    return Result.gotRocket;
                default:
                    return new Result();                    
            }
        }else if (bluff)
        {//bluff failed
            StatManager.Instance.relaxZone(plan.targetZone, plan.hysteriaProvided);
            return Result.bluffFail;
        }
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

        switch (threatBox.value)
        {
            //kidnapping
            case 1:
                plan.hysteriaProvided = 25;
                break;
            //poison
            case 2:
                plan.hysteriaProvided = 50;
                break;
            //demolitions
            case 3:
                plan.hysteriaProvided = 100;
                break;
        }

        plan.targetZone = locationBox.value - 1;

        print("money " + StatManager.Instance.cash);
        print("hysteria " + StatManager.Instance.hysteria);
        print("evidence " + StatManager.Instance.policeProgress);
        print(calculateSuccess(plan, dist, bluff));
    }

    public bool calculateLoseState()
    {
        if (StatManager.Instance.hysteria > 100)
        {
            //lose due to rioting
            return true;
        }
        if(StatManager.Instance.policeProgress > 100)
        {
            //lose due to police activity
            return true;
        }
        return false;
    }

    void defaultResults(int evidence)
    {
        StatManager.Instance.policeProgress += evidence;
        StatManager.Instance.calcMoney();
    }

}
