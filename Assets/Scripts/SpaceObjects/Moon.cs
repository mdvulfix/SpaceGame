using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class Moon : SpaceObject, INaturalBody
    {
        

        public Planet Planet {get; private set;}       
        
        public float Diameter {get; private set;}
        public float Mass {get; private set;}    
        
        public float RotationSpeed {get; private set;}


    #region Constractors

        public Moon(Planet planet)
        {
            this.Planet = planet;

        }
        
    #endregion


        void Awake()
        {
            RotationSpeed = 0.1f;
        }

        void Update()
        {
            RotationAround(RotationSpeed);
        }

    #region Functions

        // For RunTime
        public void RotationAround(float rotationSpeed)
        {
            transform.RotateAround (transform.parent.position,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);
        }

    #endregion



    }
}


