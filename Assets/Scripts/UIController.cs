using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class UIController : MonoBehaviour
{
    public enum SCREEN_STATE
    {
        NONE,
        MAIN,
        GAMEPLAY,
        END,
    }

    private SCREEN_STATE screenState;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private TimerController timer;
    [SerializeField] private ScoreController scoreController;

    [SerializeField] private GameObject mainGrp;
    [SerializeField] private GameObject gameGrp;
    [SerializeField] private GameObject endGrp;

    [SerializeField] private GameObject shootWarning;

    [SerializeField] private TextMeshProUGUI finishScoreText;
    

    void Start()
    {
        timer.OnFinishTimer += FinishTimer;
    }

    void FinishTimer()
    {
        finishScoreText.text = "Points: " + scoreController.points;
        SetScreenState(SCREEN_STATE.END);
        gameManager.FinishGame();
    }

    void StartGame()
    {
        timer.ResetTimer();
        timer.SetPauseTimer(false);
        scoreController.ResetPoints();
    }

    private void OnDisable()
    {
        timer.OnFinishTimer -= FinishTimer;
    }

    public void SetScreenState(SCREEN_STATE state)
    {
        screenState = state;

        switch (screenState)
        {
            case SCREEN_STATE.MAIN:
                mainGrp.SetActive(true);
                gameGrp.SetActive(false);
                endGrp.SetActive(false);

                timer.SetPauseTimer(true);
                break;

            case SCREEN_STATE.GAMEPLAY:
                mainGrp.SetActive(false);
                gameGrp.SetActive(true);
                endGrp.SetActive(false);

                StartGame();
                break;

            case SCREEN_STATE.END:
                mainGrp.SetActive(false);
                gameGrp.SetActive(false);
                endGrp.SetActive(true);
                break;
        }
    }

    public void DisplayShootWarning(bool show)
    {
        shootWarning.SetActive(show);
    }
}