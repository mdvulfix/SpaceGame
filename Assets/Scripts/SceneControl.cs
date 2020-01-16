using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    
    public class SceneControl : MonoBehaviour
    {
        public GameObject _Space;
        public GameObject _Sector;
        public GameObject _StarSystem;

        Space space;
        Sector[] sectors;
        StarSystem[][] starSystems;
        Star[][][] stars;

        [ExecuteInEditMode]
        void Start()
        {
            

            
            
            CreateSpace();
            CreateSectors(2);
            CreateStarSystems(1, sectors);
            CreateStars(1, starSystems);

        }

        void CreateSpace()
        {

            GameObject objSpace = Instantiate(_Space, new Vector3(0, 0, 0), Quaternion.identity);
            objSpace.name = "Space";
            objSpace.transform.SetParent(transform);
            space = objSpace.GetComponent<Space>();

        }


        void CreateSectors(int amount)
        {
            sectors = new Sector[amount];
            

            for (int i = 0; i < amount; i++)
            {
                
                GameObject objSector = Instantiate(_Sector, new Vector3((float)i, 0, 0), Quaternion.identity);
                objSector.name = "Sector:" + i;
                objSector.transform.SetParent(space.transform);
                
                sectors[i] = objSector.GetComponent<Sector>(); //new Sector(objSector, new StarSystem[5]);


            }
            space.SetSector(sectors);

        }
        
        void CreateStarSystems(int amount, Sector[]sectors)
        {
            starSystems = new StarSystem[sectors.Length][];
            for (int i = 0; i < sectors.Length; i++)
            {
                starSystems[i] = new StarSystem[amount];
                for (int j = 0; j < amount; j++)
                {
                    
                    GameObject objStarSystem = Instantiate(_StarSystem, new Vector3((float)i, 0, 0), Quaternion.identity);
                    objStarSystem.name = "StarSystem:" + i + ":"+ j;
                    objStarSystem.transform.SetParent(sectors[i].transform);
                    
                    starSystems[i][j] = objStarSystem.GetComponent<StarSystem>(); //new Sector(objSector, new StarSystem[5]);

                }
                sectors[i].SetStarSystem(starSystems[i]);

            }
        }

        void CreateStars(int amount, StarSystem[][] starSystems)
        {
            stars = new Star[sectors.Length][][];
            for (int i = 0; i < sectors.Length; i++)
            {
                //stars[i] = sectors[i].GetStarSystem().Length
                for (int j = 0; j < amount; j++)
                {
                    
                    GameObject objStarSystem = Instantiate(_StarSystem, new Vector3((float)i, 0, 0), Quaternion.identity);
                    objStarSystem.name = "StarSystem:" + i + ":"+ j;
                    objStarSystem.transform.SetParent(sectors[i].transform);
                    
                    starSystems[i][j] = objStarSystem.GetComponent<StarSystem>(); //new Sector(objSector, new StarSystem[5]);

                }
                sectors[i].SetStarSystem(starSystems[i]);

            }
        }
    }
}   












