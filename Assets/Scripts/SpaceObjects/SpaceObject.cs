using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;



namespace SpaceGame
{

    public class SpaceObject : MonoBehaviour, ISpaceObject
    {
        public string Name {get; private set;}
        public Position Coordinates {get; private set;}
        

    #region RunTime
        private void Update() 
        {
            


        }
    #endregion

       
    #region Methods
        public virtual void SetChild(ISpaceObject[] spaceObject)
        {
            Debug.Log("Требуется переопределить метод!");

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
