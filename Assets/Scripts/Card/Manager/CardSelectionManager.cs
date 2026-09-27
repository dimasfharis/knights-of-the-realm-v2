
using Unity.VisualScripting;

public enum CardState
{
    Idle,
    Hovered,
    SelectingTarget
}

public static class CardSelectionManager
{
    public static CardInteractionController ActiveCard { get; private set; }

    public static void SelectCard(CardInteractionController card)
    {
        if (ActiveCard == card) return;

        if (ActiveCard != null)
        {
            ActiveCard.CancelSelection();
        }

        ActiveCard = card;
        ActiveCard.StartSelection();
    }

    public static void DeselectCurrent()
    {
        if (ActiveCard != null)
        {
            ActiveCard.CancelSelection();
            ActiveCard = null;
        }
    }

    public static void ExecuteCurrentTarget(object target = null)
    {
        if (ActiveCard != null)
        {
            ActiveCard.Execute(target);
            ActiveCard = null;
        }
    }
}
