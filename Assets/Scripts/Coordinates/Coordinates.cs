using UnityEngine;


namespace SpaceGame
{
    [System.Serializable]
    public struct Coordinates
    {
        public Vector3 position;
        public Vector3 rotation;
        public float scale;
        public float ratio;
    
        public Coordinates (float x, float y, float z, float scale, float scaleParent = 1f)
        {
            this.position = new Vector3(x, y, z);
            this.rotation = Vector3.zero;
            this.scale = scale;
            this.ratio = scale/scaleParent;
        }


        public Coordinates (Vector3 position = default(Vector3), Vector3 rotation = default(Vector3), float scale = 1f, float ratio = 1f)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.ratio = ratio;
        }


    
    }


}