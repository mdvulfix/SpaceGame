using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class SpaceGenerator: SpaceMapGenerator
    {
        static Space _space;
        public static Space Space {get{return _space;}}
        
        static int sectorsAmount = 2;
        
        public static void Create()
        {
            GameObject objSpace = Instantiate(SpaceMapGenerator.GetPrefab(SpaceObjectPrefab.Space), new Vector3(0, 0, 0), Quaternion.identity);
            objSpace.name = "Space";
            objSpace.transform.SetParent(new GameObject().transform);
            
            Space _space = objSpace.GetComponent<Space>();
            //_space.Coordinates =
            //_space.Name =
            _space.SetChild(SectorGenerator.Create(_space, SpaceMap.AmountSectors));

            //space.index = GenerateIndex();

        }
    }
}