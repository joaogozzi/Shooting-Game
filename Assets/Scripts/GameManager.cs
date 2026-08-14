using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    [SerializeField] private TargetSpawner spawner;
    [SerializeField] private GunBehaviour gun;

    private void Start()
    {
        gun.TARGET_AIMMING += uiController.DisplayShootWarning;

        uiController.SetScreenState(UIController.SCREEN_STATE.MAIN);
        gun.StopGame(true);
        spawner.StopSpawner(true);
    }

    private void OnDestroy()
    {
        gun.TARGET_AIMMING -= uiController.DisplayShootWarning;
    }

    public void StartGame()
    {
        uiController.SetScreenState(UIController.SCREEN_STATE.GAMEPLAY);

        gun.StopGame(false);
        spawner.StopSpawner(false);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        uiController.SetScreenState(UIController.SCREEN_STATE.GAMEPLAY);

        spawner.RestartSpawn();

        gun.StopGame(false);
        spawner.StopSpawner(false);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void FinishGame()
    {
        Cursor.visible = true;

        spawner.StopSpawner(true);
        gun.StopGame(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}