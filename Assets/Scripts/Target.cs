using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    bool moving;

    public static event Action OnTargetHit;

    float timer = 0;
    float maxTimer = 10;

    void Update()
    {
        if (!moving)
            return;

        timer -= Time.deltaTime;
        
        if(timer <= 0)
        {
            moving = false;
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        moving = true;

        timer = maxTimer;
    }

    public void Hit()
    {
        OnTargetHit?.Invoke();
        moving = false;
        gameObject.SetActive(false);
    }
}