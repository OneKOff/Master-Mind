using UnityEngine;
using System.Collections.Generic;

public class TurnManager : MonoBehaviour
{
    [Header("Turn Time")]
    public Timer TurnTimer;
    public float TurnDuration;

    public int CurrentTeamId;

    private void OnEnable()
    {
        if (TurnTimer == null)
        {
            TurnTimer = gameObject.AddComponent<Timer>();
        }

        TurnTimer.Reset(TurnDuration);

        TurnTimer.OnTimerElapsed += TurnTimer_OnTimerElapsed;
    }
    private void OnDisable()
    {
        TurnTimer.OnTimerElapsed -= TurnTimer_OnTimerElapsed;
    }

    private void TurnTimer_OnTimerElapsed()
    {
        CurrentTeamId++;
        if (CurrentTeamId >= GameController.Instance.Players.Count)
        {
            CurrentTeamId -= GameController.Instance.Players.Count;
            GameController.Instance.Players[CurrentTeamId].SelectionManager.ResetSelections(SelectionStage.None);
        }
    }
}
