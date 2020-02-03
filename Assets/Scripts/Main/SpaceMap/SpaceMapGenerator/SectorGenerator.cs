using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class SectorGenerator: SpaceMapGenerator
    {
        
        static Sector[] _sectors;
        public static Sector[] Sectors {get{return _sectors;} }
        
        
        public static Sector[] Create(Space space, int amount)
        {
            _sectors = new Sector[amount];
            

            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objSector = Instantiate(SpaceMapGenerator.GetPrefab(SpaceObjectPrefab.Sector), new Vector3(0, 0, 0), Quaternion.identity);

                _sectors[i] = objSector.GetComponent<Sector>();
                //sectors[i].index = GenerateIndex(index.ToString());
                //sectors[i].Coordinates =
                //sectors[i].Name =
                _sectors[i].SetChild(StarGenerator.Create(_sectors[i], SpaceMap.AmountStars));

                objSector.name = "Sector:" ; // + sectors[i].index;
                objSector.transform.SetParent(space.transform);

            }
            space.SetChild(_sectors);
            return _sectors;

        }
    }
}