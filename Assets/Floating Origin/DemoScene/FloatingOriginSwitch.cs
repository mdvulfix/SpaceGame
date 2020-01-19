using Assets.VampirasuStudios.ScaleSpacewithFloatingOrigin;

using UnityEngine;
using UnityEngine.UI;

namespace Assets.Vampirasu_Studios.ScaleSpace_with_Floating_Origin.DemoScene
{
    public class FloatingOriginSwitch : MonoBehaviour
    {
        private ScaleSpaceManager _scaleSpaceManager;
        public Text FloatingOriginIndicator;

        private void Awake()
        { _scaleSpaceManager = GetComponent<ScaleSpaceManager>(); }

        private bool _useFloatingOrigin = true;

        public void Switch()
        {
            _useFloatingOrigin = !_useFloatingOrigin;

            foreach (var scaleSpaceCamera in _scaleSpaceManager.Cameras)
            {
                scaleSpaceCamera.UseFloatingOrigin = _useFloatingOrigin;
            }

            FloatingOriginIndicator.text = "Floating origin active: " + _useFloatingOrigin;
        }
    }
}