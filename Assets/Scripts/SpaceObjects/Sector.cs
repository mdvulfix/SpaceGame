using UnityEngine;

namespace SpaceGame
{
       
    public class Sector : SpaceObject
    {        
        public Star[] Stars {get ; private set;}
       
        
    #region Constractors

        public Sector(Star[] stars)
        {
            
            this.Stars = stars;
        }
        
    #endregion
    
    #region RunTime
        private void FixedUpdate() 
        {
            
        }
        
    #endregion


    #region Methods

        public override void SetChild(ISpaceObject[] spaceObject)
        {
            this.Stars = spaceObject as Star[];

        }

    #endregion


    #region Functions

    #endregion

    }
}


