using UnityEngine;

namespace SpaceGame
{
    [System.Serializable]
    public struct Position
    {
        [SerializeField]
        int x;
        [SerializeField]
        int y;
        [SerializeField]
        int z;
        [SerializeField]
        int scale;
        
        public Position (int x, int y, int z, int scale)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.scale = scale;

        }
    

        public Vector3 ToVector3()
        {
            return new Vector3 ((float)x, (float)y, (float)z);

        }

        public static Position operator + (Position a, Position b) 
        {  
            
            Position position = new Position(a.x + b.x, a.y + b.y, a.z + b.z, a.scale + b.scale);
            return position;
        }  

        public static Position operator - (Position a, Position b) 
        {  
            Position position = new Position(a.x - b.x, a.y - b.y, a.z - b.z, a.scale - b.scale);
            return position;
        }
  
        public override bool Equals(System.Object obj)
        {
            if (! (obj is Position)) return false;
        
            Position position = (Position) obj;
            return x == position.x && y == position.y && z == position.z && scale == position.scale;
        }
        
        public override int GetHashCode()
        { 
            return ((x ^ y) ^ z)^scale;
        } 


        public static bool operator == (Position lhs, Position rhs) 
        {             
            return lhs.Equals(rhs);
        }

        public static bool operator != (Position lhs, Position rhs) 
        {             
            return !lhs.Equals(rhs);
        } 
        
    }

}
