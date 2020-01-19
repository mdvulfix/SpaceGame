using System;

using UnityEngine;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin.DemoScene
{
    public class CameraMover : MonoBehaviour
    {
        public Vector3 Velocity;
        private double startZoom = 10;

        private void Update()
        {
            Velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                Velocity = Velocity + new Vector3((float)-startZoom * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Velocity = Velocity + new Vector3((float)startZoom * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.W))
            {
                Velocity = Velocity + new Vector3(0, (float)startZoom * Time.deltaTime, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                Velocity = Velocity + new Vector3(0, (float)-startZoom * Time.deltaTime, 0);
            }

            double velZoom = -Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime;
            if (Math.Abs(velZoom) > 0.00001f)
            {
                var zoomMult = startZoom > 100000000 ? 100000000d : startZoom;
                velZoom = velZoom * -zoomMult * 100;
               
            }

            if (startZoom - velZoom <= 10)
            {
                velZoom = startZoom - 10;
          
               
            }
            else if (startZoom - velZoom > maxZoom)
            {
                velZoom = -(maxZoom - startZoom);
                startZoom = maxZoom;
                
            }
            startZoom -= velZoom;
            Velocity = Velocity + new Vector3(0, 0, (float)velZoom);

            ScaleSpaceManager.Instance.MoveCameras(Velocity);
            
        }
        double maxZoom = 500000000;
    }
}