using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceGame
{
    public static class PlanetGenerator
    {
        static Planet[] _planets;
        public static Planet[] Planets {get{return _planets;} }

        public static Planet[] Create(Star star, int amount)
        {
            _planets = new Planet[amount];
            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objPlanet = MonoBehaviour.Instantiate(SceneDataHandler.GetPrefab(SpaceObjectPrefab.Planet), new Vector3(0, 0, 0), Quaternion.identity);

                _planets[i] = objPlanet.GetComponent<Planet>();
                //sectors[i].index = GenerateIndex(index.ToString());
                _planets[i].SetPosition(new Coordinates(Random.Range(100,500),0,0, 10, star.Position.scale));
                //sectors[i].Name =

                Moon[] _moon = MoonGenerator.Create(_planets[i], 2);
                _planets[i].SetChild(_moon);

                objPlanet.name = "Planet:" ; // + sectors[i].index;
                objPlanet.transform.SetParent(star.transform);

            }
            return _planets;

        }

    }
}