using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class SpaceMap : SceneDataHandler
    {
        static Sector[] AllSectors;
        static Star[] AllStars;

        
        public static int AmountSectors {get; private set;}
        public static int AmountStars {get; private set;}
        public static int AmountPlanets {get; private set;}
        
        private void Awake() 
        {
            AmountSectors = 2;
            AmountSectors = 1;

        }



        public static void GanerateMap() 
        {
            SpaceMapGenerator.CreateMap();

        }
            
    }
}