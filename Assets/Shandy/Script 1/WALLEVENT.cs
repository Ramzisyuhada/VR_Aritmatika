using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WALLEVENT : MonoBehaviour
{
    // Start is called before the first frame update
    private bool canPass = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TasBelanja"))
        {
             canPass = false;
        }
    }
}
