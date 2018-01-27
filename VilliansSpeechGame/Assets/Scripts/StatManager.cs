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
    float _hysteria
    {
        get
        {
            return calcTotalHysteria();
        }
    }
    public float hysteria
    {
        get
        {
            return _hysteria;
        }
    }
    public float policeProgress = 0;
    List<CityZone> _zones = null;
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
}

public class CityZone
{

    public float hysteria = 0;

}

public enum keyItems {rocket, fuel, spacesuit, flag};