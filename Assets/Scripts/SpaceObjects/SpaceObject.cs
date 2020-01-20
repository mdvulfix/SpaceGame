using UnityEngine;



namespace SpaceGame
{
    public enum SpaceObjectIndexies
    {
        Full,
        Sector,
        Star,
        Planet,
        Moon
    }

    public class SpaceObject : MonoBehaviour
    {

        public string index;//{get; set;}
        public Position position; // {get; set;}
        
        Vector3 rotation;



  

        public string GetSpaceObjectIndex(SpaceObjectIndexies spaceObject = SpaceObjectIndexies.Full)
        {
            string id = "000:000:000:000";
            string index = this.index;
            
            switch (spaceObject)
            {
                case SpaceObjectIndexies.Full:
                {
                    id = index;
                    break;
                }
                case SpaceObjectIndexies.Sector:
                {
                    
                    //Debug.Log(index.Substring(0, 3));
                    id = index.Substring(0, 3);
                    
                    break;
                }
                case SpaceObjectIndexies.Star:
                {
                    //Debug.Log(index.Substring(4, 3));
                    id = index.Substring(4, 3);
                    break;
                }   
                 case SpaceObjectIndexies.Planet:
                {
                    //Debug.Log(index.Substring(8, 3));
                    id = index.Substring(8, 3);
                    break;
                }                
                case SpaceObjectIndexies.Moon:
                {
                    //Debug.Log(index.Substring(12, 3));
                    id = index.Substring(12, 3);
                    break;
                }                 
            }
            
            return id;
        }
    }
}
