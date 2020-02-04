using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public static class SpaceMap
    {
        static Sector[] AllSectors;
        static Star[] AllStars;

        
        public static int AmountSectors {get; private set;}
        public static int AmountStars {get; private set;}
        public static int AmountPlanets {get; private set;}
        
        private static void Awake() 
        {
            AmountSectors = 1;


        }



        public static void Ganerate() 
        {
            SpaceGenerator.Create();

        }
            
    }
}