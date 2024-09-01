using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Referensi ke UI TextMeshPro untuk menampilkan timer
    public float countdownTime = 300f; // Waktu hitung mundur dalam detik (5 menit)
    private bool isCountingDown = false; // Status apakah timer sedang aktif

    private float timeRemaining; // Waktu yang tersisa

    private void Start()
    {
        // Inisialisasi
        timeRemaining = countdownTime;
        UpdateTimerDisplay(timeRemaining);
    }

    public void StartCountdown()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            StartCoroutine(StartCountdownCoroutine());
        }
    }

    private IEnumerator StartCountdownCoroutine()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay(timeRemaining);
            yield return null;
        }

        UpdateTimerDisplay(0);
        isCountingDown = false;
        // OnCountdownComplete(); // Panggil jika perlu
    }

    public void StopTimer()
    {
        isCountingDown = false;
        StopAllCoroutines();
        UpdateTimerDisplay(0); // Set waktu ke nol
    }

    private void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetTimeRemaining()
    {
        return timeRemaining;
    }

    public bool IsCountingDown()
    {
        return isCountingDown;
    }
}
