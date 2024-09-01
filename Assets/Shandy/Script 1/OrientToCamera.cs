using UnityEngine;

//Place on Canvas Object
// Text -> Canvas (this) -> Model Object (-> = is parented to...)
public class OrientToCamera : MonoBehaviour
{
    private Transform mainCam;
    public float distanceFromCamera = 2.0f; // Desired distance between object and camera

    private void OnEnable()
    {
        mainCam = Camera.main.transform;
        Debug.Log("Main Cam = " + mainCam.name);
    }

    private void LateUpdate()
    {
        // Calculate the direction from the camera to the object
        Vector3 directionToCamera = (transform.position - mainCam.position).normalized;

        // Set the position of the object to maintain a fixed distance from the camera
        transform.position = mainCam.position + mainCam.forward * distanceFromCamera;

        // Ensure the object always faces the camera
        transform.LookAt(mainCam);
        transform.RotateAround(transform.position, transform.up, 180f);
    }
}
