using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Sector : SpaceObject
    {

        Transform sector;
        StarSystem[] starSystems;

       
        public Sector(Transform sector)
        {
            this.sector = sector;
            starSystems = null;
            
        }
        
        public Sector(Transform sector, StarSystem[] starSystems)
        {
            
            this.sector = sector;
            SetStarSystem(starSystems);
            
        
        }
    
        public void SetStarSystem(StarSystem[] starSystems)
        {
            this.starSystems = starSystems;

        }
        
        public StarSystem[] GetStarSystem()
        {
            return starSystems;
        }



    }
}


