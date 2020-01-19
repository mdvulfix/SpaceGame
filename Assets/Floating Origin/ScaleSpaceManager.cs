using System;

using UnityEngine;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin
{
    public class ScaleSpaceManager : MonoBehaviour
    {
        public static ScaleSpaceManager Instance;
        
        public ScaleSpaceCamera[] Cameras;
        
        public bool PrescanLayers = true;
        
        public Camera LocalCamera { get; private set; }
        public int MaximumScaleLayerIndex { get { return Cameras.Length - 1; } }
        
        
        public void AddObject(GameObject go, int fixedOnLayer = -1)
        {
            var c = go.AddComponent<ScaleSpaceObject>();
            if (fixedOnLayer > 0)
            {
                var scale = 1f;
                for (int i = 0; i < fixedOnLayer; i++)
                {
                    scale *= Cameras[i].Scale;
                }
                go.transform.position = go.transform.position / scale + Cameras[fixedOnLayer].Shift.AsFloat();
                go.transform.localScale = go.transform.localScale / scale;
                c.FixedOnLayer = true;
                Cameras[fixedOnLayer].AddObject(c);
            }
            else
            {
                Cameras[0].AddObject(c);
            }
        }

        public void DestroyObject(GameObject go)
        {
            var c = go.GetComponent<ScaleSpaceObject>();
            if (c == null) throw new Exception("Error no ScaleSpaceObject Component found on object for Destroy");
            c.CurrentScaleSpaceCamera.RemoveObject(c);
            Destroy(c.gameObject);
        }

        public void MoveCameras(Vector3 velocity)
        {
            //TODO: Performance
            var velo = velocity;
            foreach (var scaleSpaceCamera in Cameras)
            {
                velo = velo / scaleSpaceCamera.Scale;
                scaleSpaceCamera.Move(velo);
            }
        }

        public void RotateCameras(Quaternion rotation)
        {
            foreach (var scaleSpaceCamera in Cameras)
            {
                scaleSpaceCamera.Rotate(rotation);
            }
        }

        private void Awake()
        {
            Instance = this;
            var scale = 1f;
            for (int i = 0; i < Cameras.Length; i++)
            {
                var cam = Cameras[i];
                scale *= cam.Scale;
                cam.ScaleFromOrigin = scale;
                cam.ScaleFromOriginInverse = 1 / scale;
                cam.Initialize(i);
            }
            LocalCamera = Cameras[0].GetComponent<Camera>();
            if (PrescanLayers) LoadExisitingObjects();
        }

        private void LoadExisitingObjects()
        {
            foreach (var scaleSpaceCamera in Cameras)
            {
                foreach (Transform t in scaleSpaceCamera.Container.transform)
                {
                    if (t == scaleSpaceCamera.transform) continue;
                    AddObject(t.gameObject);
                }
            }
        }
        private void Update()
        {
            for (int i = 0; i < Cameras.Length; i++)
            {
                Cameras[i].DoUpdate();
            }
        }
    }
}