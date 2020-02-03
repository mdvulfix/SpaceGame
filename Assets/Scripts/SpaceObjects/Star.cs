using UnityEngine;

namespace SpaceGame
{
    public class Star : SpaceObject, INaturalBody
    {      
        //public ISpaceBody ParentSpaceBody {get; private set;}
        //public ISpaceBody[] ChildSpaceBody {get; private set;}
        
        public Sector Sector {get; private set;}
        public Planet[] Planets {get; private set;}
        
        
        public float Diameter {get; private set;}
        public float Mass {get; private set;}

        public float RotationSpeed {get; private set;}

        
        
        
    #region Constractors

        public Star(Sector sector, Planet[] planets)
        {
            this.Sector = sector;
            this.Planets = planets;

        }
        
    #endregion

    #region Methods

        public override void SetChild(ISpaceObject[] spaceObject)
        {
            this.Planets = spaceObject as Planet[];

        }

    #endregion

    #region RunTime
        private void FixedUpdate() 
        {
            RotationAround(RotationSpeed);
        }
        
    #endregion




    #region Functions

        public void RotationAround(float rotationSpeed)
        {
            transform.RotateAround (transform.parent.position,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
        }

   #endregion
    }

}
