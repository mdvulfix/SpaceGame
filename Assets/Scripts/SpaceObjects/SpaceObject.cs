using System.Collections;
using UnityEngine;



namespace SpaceGame
{

    public class SpaceObject : MonoBehaviour, ISelectable, ICoordinate
    {

        public Position Coordinates {get; private set;}
        
        public float rotationSpeed = 0;

 
        SetPosition();




        virtual void RotateAround()
        {
            transform.RotateAround (transform.parent.position,new Vector3(0.0f,1.0f,0.0f),20 * Time.deltaTime * rotationSpeed);

        }

        
    }
}
