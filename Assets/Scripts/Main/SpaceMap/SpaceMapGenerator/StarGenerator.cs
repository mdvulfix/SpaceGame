using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class StarGenerator
    {
        
        static Star[] _stars;
        public static Star[] Stars {get{return _stars;} }
        
        
        public static Star[] Create(Sector sector, int amount)
        {
            _stars = new Star[amount];
            
            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objStar = MonoBehaviour.Instantiate(SceneDataHandler.GetPrefab(SpaceObjectPrefab.Star), new Vector3(0, 0, 0), Quaternion.identity);

                _stars[i] = objStar.GetComponent<Star>();
                //sectors[i].index = GenerateIndex(index.ToString());
                _stars[i].SetPosition(new Coordinates(0,0,0, 100, sector.Position.scale));

                //sectors[i].Name =

                Planet[] _planet = PlanetGenerator.Create(_stars[i], 2);
                _stars[i].SetChild(_planet);

                objStar.name = "Star:" ; // + sectors[i].index;
                objStar.transform.SetParent(sector.transform);

            }
            sector.SetChild(_stars);
            return _stars;

        }
    }
}