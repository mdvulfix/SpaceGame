using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public static class SpaceGenerator
    {
        static Space _space;
        public static Space Space {get{return _space;}}
                     
        public static void Create()
        {
            
            GameObject objSpace = MonoBehaviour.Instantiate(SceneDataHandler.GetPrefab(SpaceObjectPrefab.Space), new Vector3(0, 0, 0), Quaternion.identity);
            objSpace.name = "Space";
            objSpace.transform.SetParent(SceneDataHandler.Scene.transform);
            
            Space _space = objSpace.GetComponent<Space>();
            //_space.Coordinates =
            Sector[] _sectors = SectorGenerator.Create(_space, 1);
            _space.SetChild(_sectors);

            //space.index = GenerateIndex();

        }
    }
}