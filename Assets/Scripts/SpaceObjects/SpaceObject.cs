using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceGame
{

    public class SpaceObject : MonoBehaviour, ICoordinate, ISpaceBody
    {

        public Position Coordinates {get; private set;}

        public string Name {get; protected set;}
        public float Diameter {get; protected set;}
        public float Mass {get; protected set;}
        public float RotationPeriod {get; protected set;}
        public float RotationSpeed {get; protected set;}
        public float CirculationPeriod {get; protected set;}
        public float DistanceToStar {get; protected set;} 
        



        
   




        #region SpaceBodyBehaviour
            
            public void RotationAround(float rotationSpeed)
            {
                transform.RotateAround (transform.parent.position,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);

            }

            public void CirculationAround(float circulationPeriod)
            {
                //some metod

            }

        #endregion
    }
}
