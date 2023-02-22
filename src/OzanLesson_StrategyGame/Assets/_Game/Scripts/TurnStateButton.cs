using UnityEngine;

public class TurnStateButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        GameTurnStateLogic.Instance.ChangeState(GameTurnStateLogic.GameTurnState.EnemyTurn);
    }
}