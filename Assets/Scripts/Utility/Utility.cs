using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    public static Vector3 WorldToScreenPoint(Camera camera, Vector3 position)
    {
        return camera.WorldToScreenPoint(position);
    }


}
