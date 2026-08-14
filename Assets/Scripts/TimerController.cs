using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public System.Action OnFinishTimer;

    [SerializeField] private TextMeshProUGUI timerText;

    public float timeValue { get; private set; }
    private bool stopTimer;
    float maxTimer = 60;

    private void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (stopTimer)
            return;

        timeValue -= Time.deltaTime;

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
            timeToDisplay = 0;

        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);

        if(timeToDisplay <= 0)
        {
            OnFinishTimer?.Invoke();
            stopTimer = true;
        }    
    }

    public void ResetTimer()
    {
        timeValue = maxTimer;

        stopTimer = false;

        DisplayTime(timeValue);
    }

    public void SetPauseTimer(bool IsPaused)
    {
        stopTimer = IsPaused;
    }
}