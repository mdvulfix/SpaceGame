using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



namespace SpaceGame
{

    public class SpaceObject : MonoBehaviour, ISpaceObject
    {
        public string Name {get; protected set;}
        public Coordinates Position {get; protected set;}
        public Coordinates _position;
        

        #region RunTime
        private void Awake() 
        {


        }

        private void Update() 
        {
            


        }
        #endregion

       
        #region Methods
        public virtual void SetChild(ISpaceObject[] spaceObject)
        {
            Debug.Log("Требуется переопределить метод!");

        }
        public void SetPosition(Coordinates position)
        {
            this.Position = position;
            this._position = position;
            this.transform.position = Position.position;
            this.transform.localScale *= Position.scale;


        }


           
        #endregion
       
     
       
       
        #region SelectionHandler


        public void OnPointerClick(PointerEventData eventData)
        {


        }


        public void OnSelect(BaseEventData eventData)
        {


        }


        public void OnDeselect(BaseEventData eventData)
        {



        }

        #endregion
        
    }
}
