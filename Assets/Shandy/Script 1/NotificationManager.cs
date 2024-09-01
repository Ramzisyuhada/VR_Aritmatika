using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationManager : MonoBehaviour
{
    public TextMeshProUGUI notificationText; // TextMeshPro untuk notifikasi
    public Button yesButton;                 // Tombol Yes
    public Button noButton;                  // Tombol No
    public Collider triggerCollider;         // Collider untuk trigger
    public Collider blockCollider;           // Collider untuk penghalang
    public CountdownTimer countdownTimer;    // Referensi ke CountdownTimer

    private bool canPass = false;            // Variabel untuk mengatur akses

    private void Start()
    {
        // Menyembunyikan notifikasi di awal
        notificationText.gameObject.SetActive(false);

        // Menambahkan listener untuk tombol Yes
        yesButton.onClick.AddListener(OnYesButtonClicked);

        // Menambahkan listener untuk tombol No
        noButton.onClick.AddListener(OnNoButtonClicked);

        // Mencari komponen CountdownTimer di scene
        countdownTimer = FindObjectOfType<CountdownTimer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TasBelanja") && !canPass)
        {
            // Tampilkan notifikasi
            notificationText.text = "Apakah Sudah Selesai Berbelanja?";
            notificationText.gameObject.SetActive(true);

            // Menghentikan waktu
            // Time.timeScale = 0f; // Jangan hentikan seluruh gameplay
        }
    }

    private void OnYesButtonClicked()
    {
        if (countdownTimer != null)
        {
            countdownTimer.StopTimer(); // Menghentikan timer dan set waktu ke nol
        }

        // Menyembunyikan notifikasi
        notificationText.gameObject.SetActive(false);

        // Menonaktifkan trigger collider untuk mencegah interaksi lebih lanjut
        triggerCollider.enabled = false;

        // Menonaktifkan block collider sebagai penghalang
        blockCollider.enabled = false;

        // Set canPass ke true
        canPass = true;
        Debug.Log("Yes button clicked, canPass set to true.");
    }

    private void OnNoButtonClicked()
    {
        // Menyembunyikan notifikasi
        notificationText.gameObject.SetActive(false);

        // Mengaktifkan kembali trigger collider jika diperlukan
        triggerCollider.enabled = true;

        // Set canPass ke false
        canPass = false;
        Debug.Log("No button clicked, canPass set to false.");
    }
}
