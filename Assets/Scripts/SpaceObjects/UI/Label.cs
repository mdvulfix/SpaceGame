using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Name
{
    [System.Serializable]
    public class Label : MonoBehaviour
    {
        [SerializeField] Text spaceObjectLabel;
        [SerializeField] Image spaceObjectPanel;
        [SerializeField] Camera activeCamera;

        Bounds spaceObjectBoundes;

        private void Awake() 
        {
            spaceObjectBoundes = transform.GetComponent<Renderer>().bounds;
        }


        private void Update() 
        {       
            spaceObjectLabel.transform.localPosition = GetTitlePosition();

        }

        Vector3 GetTitlePosition()
        {
            Vector3 position = Utility.WorldToScreenPoint(activeCamera, spaceObjectBoundes.center);
            position.y = position.y - Screen.height / 2;
            position.x = position.x - Screen.width / 2;

            return position;
        }


    }

}
