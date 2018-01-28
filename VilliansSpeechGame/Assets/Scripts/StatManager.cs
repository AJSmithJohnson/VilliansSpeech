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
    float _cash = 0;
    public float cash
    {
        get { return _cash; }
        set
        {
            _cash = (value >= 0) ? value : 0;
        }
    }
    public float hysteria
    {
        get
        {
            return calcTotalHysteria();
        }
    }
    public float policeProgress = 0;
    public List<CityZone> _zones;
    public List<CityZone> zones
    {
        get
        {
            if (_zones == null)
            {
                _zones = new List<CityZone>();
                _zones.Add(new CityZone());
                _zones.Add(new CityZone());
                _zones.Add(new CityZone());
                _zones.Add(new CityZone());
            }
            return _zones;
        }
    }

    public int robbers = 0;
    public int thugs = 0;
    public int pols = 0;

    public Result nextResult;

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
        Debug.Log(zones.Count);
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

    public float _hysteria = 0;
    public float hysteria
    {
        get { return _hysteria; }
        set{
            _hysteria = (value >= 0) ? value : 0;
        }
    }

}

public enum keyItems {rocket, fuel, spacesuit, flag};