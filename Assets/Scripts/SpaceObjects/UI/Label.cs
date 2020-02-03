using UnityEngine;
using UnityEngine.UI;


namespace SpaceGame
{
    [System.Serializable]
    public class Label : MonoBehaviour
    {
        [SerializeField] Text objectLabel;
        [SerializeField] Image objectPanel;


        Bounds spaceObjectBoundes;

        private void Awake() 
        {
            spaceObjectBoundes = transform.GetComponent<Renderer>().bounds;
            GameObject objLabelInstance = (GameObject)Instantiate(Utility.ObjectLabelPrefab, transform.position, transform.rotation);
            objLabelInstance.transform.parent = Utility.UI.transform;
            objectLabel = objLabelInstance.GetComponent<Text>();
            objectPanel = objLabelInstance.GetComponent<Image>();
        }
        
        private void Start()
        {


        }


        private void Update() 
        {       
            objectLabel.transform.localPosition = GetTitlePosition();

        }

        Vector3 GetTitlePosition()
        {
            Vector3 position = Utility.WorldToScreenPoint(Camera.main, spaceObjectBoundes.center);
            position.y = position.y - Screen.height / 2;
            position.x = position.x - Screen.width / 2;

            return position;
        }

        public Image GetPanel()
        {
            return objectPanel;

        }
    }

}
