using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager
{
    static StatManager _instance;
    public static StatManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new StatManager();
            }
            return _instance;
        }
    }
    public float cash = 0;
    public float hysteria
    {
        get
        {
            return calcTotalHysteria();
        }
    }
    public float policeProgress = 0;
    public List<CityZone> zones
    {
        get
        {
            if (zones == null)
            {
                zones = new List<CityZone>();
                zones.Add(new CityZone());
                zones.Add(new CityZone());
                zones.Add(new CityZone());
                zones.Add(new CityZone());
            }
            return zones;
        }
        set
        {
            zones = value;
        }
    }

    public int robbers = 0;
    public int thugs = 0;
    public int pols = 0;

    float calcTotalHysteria()
    {
        float averageHysteria = 0;
        foreach (CityZone cz in zones)
        {
            averageHysteria += cz.hysteria;
        }
        averageHysteria /= 4;
        return averageHysteria;
    }

    public void terrorizeZone(int targetZone, float addedHysteria)
    {
        zones[targetZone].hysteria += addedHysteria;
    }

    public void relaxZone(int targetZone, float addedHysteria)
    {
        zones[targetZone].hysteria -= addedHysteria;
    }

    public void calcMoney()
    {
        cash += robbers * 10 + thugs * 20 - pols * 10;
    }
}

public class CityZone
{

    public float hysteria = 0;

}

public enum keyItems {rocket, fuel, spacesuit, flag};