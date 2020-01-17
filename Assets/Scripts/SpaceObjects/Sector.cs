using UnityEngine;

namespace SpaceGame
{
    public class Sector : SpaceObject
    {        
        [SerializeField]
        Star[] stars;
        
        public Sector(Star[] stars)
        {
            SetStar(stars);
        }
    
        public void SetStar(Star[] stars)
        {
            this.stars = stars;

        }
        
        public Star[] GetStar()
        {
            return stars;
        }
    }
}


