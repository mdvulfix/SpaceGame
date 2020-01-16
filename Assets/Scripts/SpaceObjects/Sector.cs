using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Sector : SpaceObject
    {
        [SerializeField]
        GameObject sector;
        
        [SerializeField]
        StarSystem[] starSystems;

       
        public Sector(GameObject sector)
        {
            this.sector = sector;
            starSystems = null;
            
        }
        
        public Sector(GameObject sector, StarSystem[] starSystems)
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


