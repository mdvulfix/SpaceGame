using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SpaceGame
{
    public static class MoonGenerator
    {
        static Moon[] _moons;
        public static Moon[] Moons {get{return _moons;} }

        public static Moon[] Create(Planet planet, int amount)
        {
            _moons = new Moon[amount];
            for (int index = 1, i = 0; i < amount; index++, i++)
            {
                GameObject objMoon = MonoBehaviour.Instantiate(SceneDataHandler.GetPrefab(SpaceObjectPrefab.Moon), new Vector3(0, 0, 0), Quaternion.identity);

                _moons[i] = objMoon.GetComponent<Moon>();
                //sectors[i].index = GenerateIndex(index.ToString());
                _moons[i].SetPosition(new Coordinates(Random.Range(50,100),0,0, 5, planet.Position.scale));
                //sectors[i].Name =

                objMoon.name = "Moon:" ; // + sectors[i].index;
                objMoon.transform.SetParent(planet.transform);

            }
            return _moons;

        }
    }
}