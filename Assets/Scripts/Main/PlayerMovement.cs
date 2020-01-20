using System;

using UnityEngine;

namespace SpaceGame
{
    
    [System.Serializable]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        
        
        float startZoom = 10f;
        float maxZoom = 500000000f;
        
        float speed = 10f;
        float sensitivity = 0.25f;

        Vector3 velocity = Vector3.zero;
        Vector3 lastMouse = new Vector3(255, 255, 255);
        
        
        void Update()
        {
            UpdateMovement();
            UpdateRotation();
            UpdateZoom();

            
        } 

        void UpdateMovement()
        {            
            if (Input.GetKey (KeyCode.W)){
                velocity += new Vector3(0, 0 , 1);
            }
            if (Input.GetKey (KeyCode.S)){
                velocity += new Vector3(0, 0, -1);
            }
            if (Input.GetKey (KeyCode.A)){
                velocity += new Vector3(-1, 0, 0);
            }
            if (Input.GetKey (KeyCode.D)){
                velocity += new Vector3(1, 0, 0);
            }

            velocity *= speed * Time.deltaTime;
            transform.Translate(velocity);            
        }

        void UpdateRotation()
        {               
            lastMouse = Input.mousePosition - lastMouse ;
            lastMouse = new Vector3(-lastMouse.y * sensitivity, lastMouse.x * sensitivity, 0);           
            
            if(Input.GetMouseButton(1)){
                transform.Rotate(lastMouse);
            }
            
            lastMouse =  Input.mousePosition;
        }

        void UpdateZoom()
        {
            float velZoom = -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
            if (Math.Abs(velZoom) > 0.00001f){
                float zoomMult = startZoom > 100000000f ? 100000000f : startZoom;
                velZoom = velZoom * -zoomMult * 100;
            }

            if (startZoom - velZoom <= 10){
                velZoom = startZoom - 10;
            }
            else if (startZoom - velZoom > maxZoom){
                velZoom = -(maxZoom - startZoom);
                startZoom = maxZoom;
            }
            startZoom -= velZoom;
            velocity += new Vector3(0, 0, velZoom);
            transform.position += velocity;
        }
    }
}
