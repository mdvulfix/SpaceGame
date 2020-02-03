using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class StarGenerator: SpaceMapGenerator
    {
        
        static Star[] _stars;
        public static Star[] Stars {get{return _stars;} }
        
        
        public static Star[] Create(Sector sector, int amount)
        {
            _stars = new Star[amount];
            

            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objStar = Instantiate(SpaceMapGenerator.GetPrefab(SpaceObjectPrefab.Star), new Vector3(0, 0, 0), Quaternion.identity);

                _stars[i] = objStar.GetComponent<Star>();
                //sectors[i].index = GenerateIndex(index.ToString());
                //sectors[i].Coordinates =
                //sectors[i].Name =
                _stars[i].SetChild(PlanetGenerator.Create(_stars[i], SpaceMap.AmountPlanets));

                objStar.name = "Star:" ; // + sectors[i].index;
                objStar.transform.SetParent(_stars[i].transform);

            }
            sector.SetChild(_stars);
            return _stars;

        }
    }
}