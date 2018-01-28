using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plan {
    public int hysteriaNeeded = 50;
    public int hysteriaProvided = 10;
    public int targetZone = 0;
    /*
     * +10 per robber
     * +20 per thug
     * -10 per politician
     */
}

public enum Result{gotMoney, gotRocket, gotFlag, gotSpacesuit, bluffFail, poison, kidnap, demolition};

public class DistributionMethod
{
    /*
    radio = 0, 1
    jumbotron = 10, 2
    tv = 20, 3
    projection = 30, 4
     */
    public int evidenceProduced = 0;
    public int successMod = 1;
}