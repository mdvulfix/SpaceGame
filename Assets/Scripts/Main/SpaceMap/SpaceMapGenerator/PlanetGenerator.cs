
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceGame
{
    public class PlanetGenerator
    {
        static Planet[] _planets;
        public static Planet[] Stars {get{return _planets;} }

        public static Planet[] Create(Star star, int amount)
        {
            _planets = new Planet[amount];

            return _planets;
        }

    }
}