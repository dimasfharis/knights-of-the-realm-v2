using UnityEngine;
using UnityEngine.EventSystems;

public class OutsideClickDetector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        CardSelectionManager.DeselectCurrent();
    }
}
