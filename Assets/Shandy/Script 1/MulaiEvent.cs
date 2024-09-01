using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MulaiEvent : MonoBehaviour
{
    public TextMeshProUGUI notificationText;
    public Button yesButton;
    public Button noButton;
    public Collider triggerCollider;  // Collider untuk trigger
    public Collider blockCollider;    // Collider untuk penghalang
    public CountdownTimer countdownTimer;

    private bool canPass = false;
    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private ActionBasedController rightController;
    public InputActionReference toggleAction;

    private void Start()
    {
        notificationText.gameObject.SetActive(false);

        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);

        blockCollider.enabled = false;  

        //if (countdownTimer != null)
        //{
        //    countdownTimer.OnCountdownFinished += ResetBlockCollider;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TasBelanja"))
        {
            notificationText.text = "Apakah anda ingin mulai berbelanja?";
            notificationText.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }
    }

    private void OnYesButtonClicked()
    {
        if (countdownTimer != null)
        {
            countdownTimer.StartCountdown();
        }

        canPass = true;
        blockCollider.enabled = true;  
        triggerCollider.enabled = false;  // Matikan trigger collider agar tidak dipicu lagi

        notificationText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Yes button clicked, mulai");
    }

    private void OnNoButtonClicked()
    {
        canPass = false;
        blockCollider.enabled = true;

        notificationText.gameObject.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("No button clicked, tidak mulai");
    }

    private void ResetBlockCollider()
    {
        canPass = false;
        blockCollider.enabled = true;  // Aktifkan penghalang kembali setelah countdown selesai
        triggerCollider.enabled = true;  // Aktifkan trigger collider kembali jika diperlukan
        Debug.Log("Collider reset, penghalang muncul kembali");
    }

   
}
