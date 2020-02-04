using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    
    public enum SpaceObjectPrefab
    {
        Space, Sector, Star, Planet, Moon
            
    }
    
    
    [System.Serializable]
    public class SceneDataHandler : MonoBehaviour
    {
        
        [SerializeField] GameObject space;
        [SerializeField] GameObject sector;
        [SerializeField] GameObject star;
        [SerializeField] GameObject planet;
        [SerializeField] GameObject moon;
        
        public static GameObject Scene {get; private set;}
        public static GameObject Space {get; private set;}
        public static GameObject Sector {get; private set;}
        public static GameObject Star {get; private set;}
        public static GameObject Planet {get; private set;}
        public static GameObject Moon {get; private set;}


        private void Awake() 
        {
            Scene = this.gameObject;
            Space = this.space;
            Sector = this.sector;
            Star = this.star;
            Planet = this.planet;
            Moon = this.moon;

            
        
        }
        
        public static GameObject GetPrefab(SpaceObjectPrefab spaceObject)
        {
            GameObject prefab = null;
            
            switch (spaceObject)
            {
                case SpaceObjectPrefab.Space: 
                {
                    prefab = Space; 
                    break;
                }
                case SpaceObjectPrefab.Sector: 
                {
                    prefab = Sector; 
                    break;
                }
                case SpaceObjectPrefab.Star: 
                {
                    prefab = Star; 
                    break;
                }
                case SpaceObjectPrefab.Planet:
                {
                    prefab = Planet; 
                    break;
                }
                case SpaceObjectPrefab.Moon:
                {
                    prefab = Moon; 
                    break;
                }
                default:
                    prefab = Scene;
                    break;
            }
            return prefab;
        }


        
        
        void Start()
        {

            SpaceMap.Ganerate();
            

            //CreateSpace();
            //CreateSectors(1);
            //CreateStars(1);
            //CreatePlanets(3);
            //CreateMoons(1);
        }

        #region Start functions-------------------------




        
        /*
        void CreatePlanets(int amount)
        {
            
            Sector[] sectors = space.Sectors;
            foreach (Sector sector in sectors)
            {
                Star[] stars = sector.Stars;
                foreach (Star star in stars)
                {
                    Planet[] planets = new Planet[amount];
                    for (int index = 1, i = 0; i < amount; index++, i++)
                    {
                        
                        GameObject objPlanet = Instantiate(PlanetPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                        
                        planets[i] = objPlanet.GetComponent<Planet>();
                        //planets[i].index = GenerateIndex(sector.GetSpaceObjectIndex(SpaceObjectIndexies.Sector), star.GetSpaceObjectIndex(SpaceObjectIndexies.Star), index.ToString());
                        
                        objPlanet.name = "Planet:"; // + planets[i].index;
                        objPlanet.transform.SetParent(star.transform);

                    }
                    star.SetChild(planets);

                }
            }
            
            

        }

        void CreateMoons(int amount)
        {
            
            Sector[] sectors = space.Sectors;
            foreach (Sector sector in sectors)
            {
                Star[] stars = sector.Stars;
                foreach (Star star in stars)
                {
                    Planet[] planets = star.Planets;
                    foreach (Planet planet in planets)
                    {                     
                        Moon[] moons = new Moon[amount];
                        for (int index = 1, i = 0; i < amount; index++, i++)
                        {
                            
                            GameObject objMoon = Instantiate(MoonPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                            
                            moons[i] = objMoon.GetComponent<Moon>();
                            //moons[i].index = GenerateIndex(sector.GetSpaceObjectIndex(SpaceObjectIndexies.Sector), star.GetSpaceObjectIndex(SpaceObjectIndexies.Star), planet.GetSpaceObjectIndex(SpaceObjectIndexies.Planet), index.ToString());
                            
                            objMoon.name = "Moon:"; // + moons[i].index;
                            objMoon.transform.SetParent(planet.transform);

                        }
                        planet.SetChild(moons);
                    }
                }
            }
        }
        
        #endregion
    
        #region Common functions-------------------------

        string GenerateIndex(string sector = "000", string star = "000", string planet ="000", string moon ="000")
        {
            if (sector.Length > 3 || star.Length > 3 || planet.Length > 3 || moon.Length > 3)
            {
                Debug.Log("Ошибка: 'Неверный индекс'");
            }
            else if(sector.Length<3)
            {
                while (sector.Length < 3)
                {
                    sector = "0"+ sector;
                }
            }
            else if(star.Length<3)
            {
                while (star.Length < 3)
                {
                    star = "0"+ star;
                }
            }
            else if(planet.Length<3)
            {
                while (planet.Length < 3)
                {
                    planet = "0"+ planet;
                }
            }
            else if(moon.Length<3)
            {
                while (moon.Length < 3)
                {
                    moon = "0"+ moon;
                }
            }               
            
            string index = sector +":"+ star +":"+ planet +":"+ moon;
            return index;
        }


        */
        #endregion
    }
}   












