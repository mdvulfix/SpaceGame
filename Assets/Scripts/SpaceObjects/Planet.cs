using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Planet : SpaceObject
    {

        [SerializeField]
        Moon[] moons;
        
        public Planet(Moon[] moons)
        {
            SetMoon(moons);
        }
    
        public void SetMoon(Moon[] moons)
        {
            this.moons = moons;

        }
        
        public Moon[] GetMoon()
        {
            return moons;
        }


    }
}



