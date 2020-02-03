
using UnityEngine;

namespace SpaceGame
{
    
    public class Utility : MonoBehaviour
    {
        
        [SerializeField] public static GameObject UI;
        [SerializeField] public static GameObject ObjectLabelPrefab;


        
        public static Vector3 WorldToScreenPoint(Camera camera, Vector3 position)
        {
            return camera.WorldToScreenPoint(position);
        }


    }

}
