using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    [Header("Debug (read only)")]
    [SerializeField] private string lastActiveState;
    [SerializeField] private string currentActiveState;

    private State currentState;

    private GameState_MainMenu gameState_MainMenu = new GameState_MainMenu();
    private GameState_Gameplay gameState_Gameplay = new GameState_Gameplay();

    private void Start()
    {
        currentState = gameState_MainMenu;
        currentState.EnterState();
        currentActiveState = currentState.ToString();
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void SwitchState(State newState)
    {
        currentState.ExitState();
        lastActiveState = currentActiveState;
        currentState = newState;
        newState.EnterState();
    }

    public void PlayGame()
    {
        SwitchState(gameState_Gameplay);
    }
}
