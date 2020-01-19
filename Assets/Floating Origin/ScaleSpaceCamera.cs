using System.Collections.Generic;

using UnityEngine;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin
{
    public class ScaleSpaceCamera : MonoBehaviour
    {
        public Transform Container;
        public string LayerName;
        public float Scale;
        public float TransitionThreshold;
        public bool UseFloatingOrigin;
        public float ShiftThreshold = 6000;


        public float ScaleFromOrigin { get; set; }
        public float ScaleFromOriginInverse { get; set; }
        
        public Vector3Double Shift;
        
        private readonly List<ScaleSpaceObject> _scaleSpaceObjects = new List<ScaleSpaceObject>();
        private ScaleSpaceCamera _currentScaleCam;
        private ScaleSpaceCamera _lowerScaleCam;
        private ScaleSpaceCamera _upperScaleCam;
        public Camera Camera { get; private set; }

        public int CurrentScaleIndex { get; set; }
        public int GetLayerMask
        {
            get { return LayerMask.NameToLayer(LayerName); }
        }

        public void AddObject(ScaleSpaceObject obj)
        {
            obj.gameObject.layer = GetLayerMask;
            obj.CurrentScaleSpaceCamera = this;
            foreach (Transform trans in obj.gameObject.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = GetLayerMask;
            }
            obj.transform.SetParent(Container);
            _scaleSpaceObjects.Add(obj);
        }

        public void DoUpdate()
        {
            if (_scaleSpaceObjects.Count == 0) return;
            for (int i = _scaleSpaceObjects.Count - 1; i >= 0; i--)
            {
                var obj = _scaleSpaceObjects[i];
                if (obj == null)
                {
                    _scaleSpaceObjects.RemoveAt(i);
                    continue;
                }
                if (obj.FixedOnLayer) continue;
                if (CurrentScaleIndex > 0)
                {
                    var d = _lowerScaleCam.TransitionThreshold / _currentScaleCam.Scale;
                    if ((obj.transform.position - _currentScaleCam.transform.position).sqrMagnitude < Mathf.Pow(d, 2))
                    {
                        obj.gameObject.transform.localScale *= _currentScaleCam.Scale;
                        obj.gameObject.transform.position += _currentScaleCam.Shift.AsFloat();
                        obj.gameObject.transform.position *= _currentScaleCam.Scale;
                        obj.gameObject.transform.position -= _lowerScaleCam.Shift.AsFloat();
                        obj.gameObject.layer = _lowerScaleCam.GetLayerMask;
                        foreach (Transform trans in obj.GetComponentsInChildren<Transform>(true))
                        {
                            trans.gameObject.layer = _lowerScaleCam.GetLayerMask;
                        }
                        obj.transform.SetParent(_lowerScaleCam.Container);
                        RemoveObject(obj);
                        _lowerScaleCam.AddObject(obj);
                        continue;
                    }
                }

                // Checking for get in bigger LocalScale
                if (CurrentScaleIndex < ScaleSpaceManager.Instance.MaximumScaleLayerIndex)
                {
                    if ((obj.transform.position - _currentScaleCam.gameObject.transform.position).sqrMagnitude
                        > Mathf.Pow(_currentScaleCam.TransitionThreshold, 2))
                    {
                        obj.gameObject.transform.localScale *= 1f / _upperScaleCam.Scale;
                        obj.gameObject.transform.position += _currentScaleCam.Shift.AsFloat();
                        obj.gameObject.transform.position *= 1f / _upperScaleCam.Scale;
                        obj.gameObject.transform.position -= _upperScaleCam.Shift.AsFloat();
                        obj.gameObject.layer = _upperScaleCam.GetLayerMask;
                        foreach (Transform trans in obj.GetComponentsInChildren<Transform>(true))
                        {
                            trans.gameObject.layer = _upperScaleCam.GetLayerMask;
                        }
                        obj.transform.SetParent(_upperScaleCam.Container);
                        RemoveObject(obj);
                        _upperScaleCam.AddObject(obj);
                    }
                }
            }
        }

        public Vector3Double GetPositionInLocalSpace()
        {
            var vd = transform.position + Shift.AsFloat();
            return new Vector3Double(vd.x, vd.y, vd.z) * ScaleFromOrigin;
        }

        public void Initialize(int camIndex)
        {
            CurrentScaleIndex = camIndex;
            if (CurrentScaleIndex > 0)
                _lowerScaleCam = ScaleSpaceManager.Instance.Cameras[CurrentScaleIndex - 1];
            _currentScaleCam = this;
            if (CurrentScaleIndex < ScaleSpaceManager.Instance.MaximumScaleLayerIndex)
                _upperScaleCam = ScaleSpaceManager.Instance.Cameras[CurrentScaleIndex + 1];
        }

        public void Move(Vector3 velocity)
        {
            transform.position += velocity;
            if (!UseFloatingOrigin) return;
            if (transform.position.magnitude > ShiftThreshold)
            {
                var shift = transform.position;
                ApplyShiftToScene(shift);
                Shift += shift;
            }
        }
        public void RemoveObject(ScaleSpaceObject obj)
        {
            _scaleSpaceObjects.Remove(obj);
        }

        public void Rotate(Quaternion rotation) { transform.rotation = rotation; }

        private void ApplyShiftToScene(Vector3 shift)
        {
            //Debug.Log(LayerName + " : shift Scene");
            for (int i = 0; i < _scaleSpaceObjects.Count; i++)
            {
                _scaleSpaceObjects[i].gameObject.transform.position -= shift;
            }
            /*
            var objects = FindObjectsOfType(typeof(ParticleEmitter));
            foreach (var o in objects)
            {
                var pe = (ParticleEmitter)o;
                if (pe == null) continue;
                if (pe.gameObject.layer != GetLayerMask)
                    continue;
                var particles = pe.particles;
                int numParticlesAlive = particles.Length;
                for (int i = 0; i < numParticlesAlive; ++i)
                {
                    particles[i].position = particles[i].position - shift;
                }
                pe.particles = particles;
                pe.worldVelocity = Vector3.zero;
                pe.Simulate(0.00000000001f);
            }

            objects = FindObjectsOfType(typeof(ParticleSystem));
            foreach (var o in objects)
            {
                var pe = (ParticleSystem)o;
                if (pe == null) continue;
                if (pe.gameObject.layer != GetLayerMask)
                     continue;

                if (pe.simulationSpace == ParticleSystemSimulationSpace.Local) continue;
                ParticleSystem.Particle[] emitterParticles = new ParticleSystem.Particle[pe.maxParticles];
                int numParticlesAlive = pe.GetParticles(emitterParticles);

                for (int i = 0; i < numParticlesAlive; ++i)
                {
                    emitterParticles[i].position = emitterParticles[i].position - shift;
                }
                pe.SetParticles(emitterParticles, numParticlesAlive);

                pe.Simulate(0.00000000001f, true, false);
                pe.Play();
            }
            */
            //objects = Object.FindObjectsOfType(typeof(Rigidbody));
            //foreach (Object o in objects)
            //{
            //    Rigidbody r = (Rigidbody)o;
            //    {
            //        if (r.gameObject.layer != GetLayerMask) continue;

            //        r.sleepThreshold = float.MaxValue;
            //       // r.sleepThreshold = float.MaxValue;
            //    }
            //}

            transform.position -= shift;
        }

        private void Awake() { Camera = GetComponent<Camera>(); }
    }
}