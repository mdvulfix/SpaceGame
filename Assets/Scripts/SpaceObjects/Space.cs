using UnityEngine;

namespace SpaceGame
{
    public class Space : SpaceObject
    {
        [SerializeField]   
        Sector[] sectors;

        public void SetSector(Sector[] sectors)
        {
            this.sectors = sectors;

        }
        
        public Sector[] GetSector()
        {
            return sectors;
        }

    } 
}


