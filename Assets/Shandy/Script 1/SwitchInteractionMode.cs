using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RayInteractorVisualToggle : MonoBehaviour
{
    [SerializeField] private ActionBasedController leftController;
    [SerializeField] private ActionBasedController rightController;
    public InputActionReference toggleAction; // Reference to the input action

    private bool isRayVisualActive = true;

    private void OnEnable()
    {
        if (toggleAction != null)
        {
            toggleAction.action.Enable();
            toggleAction.action.started += OnToggleAction;
            Debug.Log("Input action enabled and toggle event subscribed.");
        }
        else
        {
            Debug.LogWarning("Toggle action reference is not set.");
        }
    }

    private void OnDisable()
    {
        if (toggleAction != null)
        {
            toggleAction.action.Disable();
            toggleAction.action.started -= OnToggleAction;
            Debug.Log("Input action disabled and toggle event unsubscribed.");
        }
    }

    private void OnToggleAction(InputAction.CallbackContext context)
    {
        ToggleRayVisual();
    }

    private void ToggleRayVisual()
    {
        isRayVisualActive = !isRayVisualActive;
        Debug.Log($"Toggling ray visual. New state: {isRayVisualActive}");

        // Handle Left Controller
        ToggleRayVisualForController(leftController);

        // Handle Right Controller
        ToggleRayVisualForController(rightController);
    }

    private void ToggleRayVisualForController(ActionBasedController controller)
    {
        if (controller != null)
        {
            var lineVisual = controller.GetComponentInChildren<XRInteractorLineVisual>(true);

            if (lineVisual != null)
            {
                lineVisual.enabled = isRayVisualActive;
                Debug.Log($"Controller: {controller.name} - Ray Visual Enabled: {lineVisual.enabled}");
            }
            else
            {
                Debug.LogWarning($"{controller.name} does not have an XRInteractorLineVisual component.");
            }
        }
        else
        {
            Debug.LogWarning("Controller not found or not valid.");
        }
    }

    private void Update()
    {
        if (toggleAction != null && toggleAction.action.WasPressedThisFrame())
        {
            Debug.Log("Toggle Action Pressed");
        }
    }
}
