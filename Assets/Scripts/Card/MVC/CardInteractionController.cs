
public class CardInteractionController
{
    public CardState CurrentState { get; private set; } = CardState.Idle;
    public bool IsPointerOver {  get; private set; }

    public event System.Action<CardState> OnStateChanged;
    public event System.Action<object> OnCardExecuted;

    #region State Transition Control

    public void StartSelection()
    {
        ChangeState(CardState.SelectingTarget);
    }

    public void CancelSelection()
    {
        ChangeState(IsPointerOver ? CardState.Hovered : CardState.Idle);
    }

    public void Execute(object target)
    {
        OnCardExecuted?.Invoke(target);
        ChangeState(CardState.Idle);
    }

    private void ChangeState(CardState newState)
    {
        CurrentState = newState;
        OnStateChanged?.Invoke(CurrentState);
    }

    #endregion

    #region Pointer Events

    public void OnPointerEnter()
    {
        IsPointerOver = true;

        if (CurrentState == CardState.Idle)
        {
            ChangeState(CardState.Hovered);
        }
    }

    public void OnPointerExit()
    {
        IsPointerOver = false;

        if (CurrentState == CardState.Hovered)
        {
            ChangeState(CardState.Idle);
        }
    }

    public void OnPointerClick()
    {
        CardSelectionManager.SelectCard(this);
    }

    #endregion
}
