using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceGame
{
    public class SceneControl : MonoBehaviour
    {
        public GameObject _Space;
        
        public GameObject _Sector;
        public GameObject _Star;
        public GameObject _Planet;
        public GameObject _Moon;
        
        Space space;
        
        void Start()
        {
            CreateSpace();
            CreateSectors(1);
            CreateStars(1);
            CreatePlanets(1);
            CreateMoons(1);

        }

        #region Start functions-------------------------

        [ExecuteInEditMode] 
        void CreateSpace()
        {

            //GameObject objSpace = Instantiate(_Space, new Vector3(0, 0, 0), Quaternion.identity);
            //objSpace.name = "Space";
            //objSpace.transform.SetParent(transform);
            
            GameObject objSpace = _Space;
            space = objSpace.GetComponent<Space>();
            space.index = GenerateIndex();

        }

        void CreateSectors(int amount)
        {
            Sector[] sectors = new Sector[amount];
            

            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objSector = Instantiate(_Sector, new Vector3(0, 0, 0), Quaternion.identity);

                sectors[i] = objSector.GetComponent<Sector>();
                sectors[i].index = GenerateIndex(index.ToString());
                objSector.name = "Sector:" + sectors[i].index;
                objSector.transform.SetParent(space.transform);

            }
            space.SetSector(sectors);

        }
        
        void CreateStars(int amount)
        {    
            Sector[] sectors = space.GetSector();                 
            foreach (Sector sector in sectors)
            {
                Star[] stars = new Star[amount];
                for (int index = 1, i = 0; i < amount; index++, i++)
                {
                    
                    GameObject objStar = Instantiate(_Star, new Vector3(0, 0, 0), Quaternion.identity);
                    
                    stars[i] = objStar.GetComponent<Star>();
                    stars[i].index = GenerateIndex(sector.GetSpaceObjectIndex(SpaceObjectIndexies.Sector), index.ToString());
                    
                    objStar.name = "Star:" + stars[i].index;
                    objStar.transform.SetParent(sector.transform);
                    
                    

                }
                sector.SetStar(stars);
            }
        }

        void CreatePlanets(int amount)
        {
            
            Sector[] sectors = space.GetSector();
            foreach (Sector sector in sectors)
            {
                Star[] stars = sector.GetStar();
                foreach (Star star in stars)
                {
                    Planet[] planets = new Planet[amount];
                    for (int index = 1, i = 0; i < amount; index++, i++)
                    {
                        
                        GameObject objPlanet = Instantiate(_Planet, new Vector3(0, 0, 0), Quaternion.identity);
                        
                        planets[i] = objPlanet.GetComponent<Planet>();
                        planets[i].index = GenerateIndex(sector.GetSpaceObjectIndex(SpaceObjectIndexies.Sector), star.GetSpaceObjectIndex(SpaceObjectIndexies.Star), index.ToString());
                        
                        objPlanet.name = "Planet:" + planets[i].index;
                        objPlanet.transform.SetParent(star.transform);

                    }
                    star.SetPlanet(planets);

                }
            }
            
            

        }

        void CreateMoons(int amount)
        {
            
            Sector[] sectors = space.GetSector();
            foreach (Sector sector in sectors)
            {
                Star[] stars = sector.GetStar();
                foreach (Star star in stars)
                {
                    Planet[] planets = star.GetPlanet();
                    foreach (Planet planet in planets)
                    {                     
                        Moon[] moons = new Moon[amount];
                        for (int index = 1, i = 0; i < amount; index++, i++)
                        {
                            
                            GameObject objMoon = Instantiate(_Moon, new Vector3(0, 0, 0), Quaternion.identity);
                            
                            moons[i] = objMoon.GetComponent<Moon>();
                            moons[i].index = GenerateIndex(sector.GetSpaceObjectIndex(SpaceObjectIndexies.Sector), star.GetSpaceObjectIndex(SpaceObjectIndexies.Star), planet.GetSpaceObjectIndex(SpaceObjectIndexies.Planet), index.ToString());
                            
                            objMoon.name = "Moon:" + moons[i].index;
                            objMoon.transform.SetParent(planet.transform);

                        }
                        planet.SetMoon(moons);
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



        #endregion
    
    }
}   












