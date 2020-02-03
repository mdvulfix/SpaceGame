using UnityEngine;

namespace SpaceGame
{
    public class Space : SpaceObject
    {
        public Sector[] Sectors {get; private set;}

    #region Constractors

        public Space(Sector[] sectors)
        {
            this.Sectors = sectors;
 

        }
        
    #endregion


    #region Methods

        public override void SetChild(ISpaceObject[] spaceObject)
        {
            this.Sectors = spaceObject as Sector[];

        }

    #endregion

    }
}


