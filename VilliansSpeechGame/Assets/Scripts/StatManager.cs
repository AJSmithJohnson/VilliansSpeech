using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager
{

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
    List<CityZone> zones
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

public enum Henchman { thug, robber, politician };
public enum KeyItem { battery, focusingCrystal, artillery };