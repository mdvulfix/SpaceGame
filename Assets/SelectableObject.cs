using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceGame
{   

    public class SelectableObject : MonoBehaviour, ISelectable
    {
        Color standartColor;
        Renderer objRenderer;
        GameObject objLabel;


        public static HashSet<ISelectable> AllSelectableObjects = new HashSet<ISelectable>();
        public static HashSet<ISelectable> AllSelectedObject = new HashSet<ISelectable>();
        
        private void Awake() 
        {   
            objRenderer = GetComponent<Renderer>();
            objLabel = GetComponent<Label>().GetPanel().gameObject;
            standartColor = objRenderer.material.color;
        }
        
    #region PointerHandler
        
        public void OnPointerEnter(PointerEventData eventData)
        {

        }

        public void OnPointerExit (PointerEventData eventData)
        {
           objLabel.SetActive(false);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            DeselectAllSelectedObjects();
            OnSelect(eventData);
        }

    #endregion
              
    #region SelectionHandler
        
        public void OnSelect(BaseEventData eventData)
        {
            OnDeselect(eventData);
            SelectObject();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            DeselectObject();
        }

    #endregion
        
        public void SelectObject()
        {
            //Debug.Log("Start selection...");
            AllSelectedObject.Add(this);
            transform.GetComponent<Renderer>().material.color = Color.green;
            //objLabel.SetActive(true);

        }

        public void DeselectObject()
        {
            //Debug.Log("Finsh selection...");
            transform.GetComponent<Renderer>().material.color = standartColor;
            //objLabel.SetActive(false);

        }

        public static void DeselectAllSelectedObjects()
        {
            foreach (ISelectable sObj in AllSelectedObject)
            {
                sObj.DeselectObject();
            }
            AllSelectedObject.Clear();
                    
        }

        public static int AllSelectedObjectCount()
        {
            return AllSelectedObject.Count;
                    
        }
    }
}
