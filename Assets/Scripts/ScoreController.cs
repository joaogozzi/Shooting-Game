using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public int points { get; private set; }

    private void OnEnable()
    {
        Target.OnTargetHit += AddPoint;

        DisplayPoints();
    }

    private void OnDisable()
    {
        Target.OnTargetHit -= AddPoint;
    }

    void AddPoint()
    {
        points++;

        DisplayPoints();
    }

    void DisplayPoints()
    {
        scoreText.text = "Points: " + points;
    }

    public void ResetPoints()
    {
        points = 0;
    }
}