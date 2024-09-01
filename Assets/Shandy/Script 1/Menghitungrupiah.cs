using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Menghitungrupiah : MonoBehaviour
{
    public GameObject targetObject; // Objek yang menjadi target untuk didekati
    public float destroyDistance = 0.5f; // Jarak maksimum untuk trigger destroy
    private bool isBeingHeld = false;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }

    void Update()
    {
        // Memeriksa jarak antara objek yang dipegang dan target object
        if (isBeingHeld && targetObject != null && Vector3.Distance(transform.position, targetObject.transform.position) <= destroyDistance)
        { 
            Destroy(gameObject);
            ScoreManager.instance.kurangScore();
            ScoreManager.instance.Tambahpoin();
        }
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isBeingHeld = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isBeingHeld = false;
    }
}
