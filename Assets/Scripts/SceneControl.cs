using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    
    public class SceneControl : MonoBehaviour
    {

        [SerializeField]
        Transform space;

        [SerializeField]
        Transform sector;
        
        [SerializeField]
        Sector[] sectors;
        
        [SerializeField]
        Transform starSystem;


        void Start()
        {
            CreateSpace();
            CreateSectors(2);
        }

        void CreateSpace()
        {
            //space = new Space(space);


        }

        void CreateSectors(int amount)
        {
            sectors = new Sector[amount];
            for (int i = 0; i < amount; i++)
            {
                sectors[i] = new Sector(Instantiate(sector, new Vector3((float)i, 0, 0), Quaternion.identity));
                sectors[i].SetStarSystem(new StarSystem[1]);

            }




        }





    }
}   












