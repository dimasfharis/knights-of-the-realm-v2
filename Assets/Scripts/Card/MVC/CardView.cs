using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private CardInteractionController cardController;

    // Bridge Unity EventSystem to controller logic
    public void OnPointerEnter(PointerEventData eventData) => cardController.OnPointerEnter();
    public void OnPointerExit(PointerEventData eventData) => cardController.OnPointerExit();
    public void OnPointerClick(PointerEventData eventData) => cardController.OnPointerClick();

    #region Initialization

    private void Awake()
    {
        cardController = new CardInteractionController();
        cardController.OnStateChanged += HandleStateChanged;
        cardController.OnCardExecuted += HandleCardExecuted;
    }

    private void OnDestroy()
    {
        cardController.OnStateChanged -= HandleStateChanged;
        cardController.OnCardExecuted -= HandleCardExecuted;
    }

    #endregion

    #region Visual Reaction Handlers

    private void HandleStateChanged(CardState state)
    {
        switch (state)
        {
            case CardState.Idle:
                transform.localScale = Vector3.one;
                break;

            case CardState.Hovered:
                transform.localScale = Vector3.one * 1.1f;
                break;

            case CardState.SelectingTarget:
                transform.localScale = Vector3.one * 1.3f;
                Debug.Log("Card Selected");
                break;
        }
    }

    private void HandleCardExecuted(object target)
    {
        Debug.Log("Card Executed");
    }

    #endregion
}