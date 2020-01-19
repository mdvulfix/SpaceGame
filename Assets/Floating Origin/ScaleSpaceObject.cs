using UnityEngine;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin
{
    public class ScaleSpaceObject : MonoBehaviour
    {
        public bool FixedOnLayer;
        public float ScaleFromOrigin { get { return CurrentScaleSpaceCamera.ScaleFromOrigin; } }
        public float ScaleFromOriginInverse { get { return CurrentScaleSpaceCamera.ScaleFromOriginInverse; } }

        public ScaleSpaceCamera CurrentScaleSpaceCamera;

        public Vector3 GetPositionInLocalSpace()
        {
            return (transform.position + CurrentScaleSpaceCamera.Shift.AsFloat()) * ScaleFromOrigin;
        }

        public void AddVelocityFromLocalSpace(Vector3 vectorToAdd) { transform.position += vectorToAdd * ScaleFromOriginInverse; }

    }
}