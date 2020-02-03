using UnityEngine.EventSystems;

namespace SpaceGame
{
    public interface ISelectable: IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
    {
        void SelectObject();
        void DeselectObject();
    }


}

