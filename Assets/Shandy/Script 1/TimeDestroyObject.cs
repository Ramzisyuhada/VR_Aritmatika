using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroyObject : MonoBehaviour
{
    public CountdownTimer countdownTimer;

    private void Start()
    {
        if (countdownTimer != null)
        {
            float timeRemaining = countdownTimer.GetTimeRemaining();
            Debug.Log("Waktu tersisa: " + timeRemaining);
        }
    }

    private void Update()
    {
        if (countdownTimer != null && countdownTimer.IsCountingDown())
        {
            float timeRemaining = countdownTimer.GetTimeRemaining();
            Debug.Log("Waktu tersisa: " + timeRemaining);

            if (timeRemaining <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
