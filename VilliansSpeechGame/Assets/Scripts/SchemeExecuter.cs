using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchemeExecuter : MonoBehaviour {

    Result result;

	public Result calculateSuccess(Plan plan, DistributionMethod dist, bool bluff = false)
    {
        defaultResults(dist.evidenceProduced);

        if ((StatManager.Instance.hysteria + StatManager.Instance.pols) * dist.successMod > plan.hysteriaNeeded)
        {
            return new Result();//success
        }else if (bluff)
        {
            StatManager.Instance.relaxZone(plan.targetZone, plan.hysteriaProvided);
            return new Result();//bluff failed
        }
        StatManager.Instance.terrorizeZone(plan.targetZone, plan.hysteriaProvided);
        StatManager.Instance.policeProgress += (StatManager.Instance.thugs * 20 + StatManager.Instance.robbers * 10 - StatManager.Instance.pols * 10);
        return new Result();//enacted plan
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
