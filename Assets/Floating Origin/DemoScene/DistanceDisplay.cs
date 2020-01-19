using UnityEngine;
using UnityEngine.UI;

namespace Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin.DemoScene
{
    public class DistanceDisplay : MonoBehaviour
    {
        private Text _text;

        void Awake()
        {
            _text = GetComponent<Text>(); 
        }

        void Update()
        {
            var dist = ScaleSpaceManager.Instance.Cameras[0].GetPositionInLocalSpace();
            _text.text = dist.AsFloat().magnitude.ToString("N0") + "m";
        }
    }
}
