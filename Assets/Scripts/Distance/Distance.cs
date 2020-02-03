using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance
{

    float Meter {get; set;} // метр
    float Kilometer {get; set;} // километр
    float Astrounit {get; set;} // астронамическая еденица
    float Parsec {get; set;} // парсек

    float ConvertToKilometer()
    {
        return Meter/1000f;
    }

    float ConvertToAstrounit()
    {
        return Kilometer/149597870.7f;

    }

    float ConvertToParsec()
    {
        return Astrounit/206264.8f;

    }


}
