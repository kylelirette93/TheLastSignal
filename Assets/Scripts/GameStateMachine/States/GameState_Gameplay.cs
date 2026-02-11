using UnityEngine;

public class GameState_Gameplay : State
{
    public override void EnterState()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UIManager.Instance.ShowGameplay();
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }
}
