using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Planet : SpaceObject, INaturalBody
    {

        public Star Star {get; private set;}
        public Moon[] Moons {get; private set;}
        
        
        public float Diameter {get; private set;}
        public float Mass {get; private set;}

        public float RotationSpeed {get; private set;}
              

    #region Constractors

        public Planet(Star star, Moon[] moons)
        {
            this.Star = star;
            this.Moons = moons;

        }
        
    #endregion

    #region Methods

        public override void SetChild(ISpaceObject[] spaceObject)
        {
            this.Moons = spaceObject as Moon[];

        }

    #endregion

    #region RunTime

        void Awake()
        {
            RotationSpeed = 0.1f;
        }

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



