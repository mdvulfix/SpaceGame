using UnityEngine;

namespace SpaceGame
{
    public class Star : SpaceObject
    {      
        [SerializeField]
        Planet[] planets;
        
        public Star(Planet[] planets)
        {
            SetPlanet(planets);
        }
    
        public void SetPlanet(Planet[] planets)
        {
            this.planets = planets;

        }
        
        public Planet[] GetPlanet()
        {
            return planets;
        }


    }

}
