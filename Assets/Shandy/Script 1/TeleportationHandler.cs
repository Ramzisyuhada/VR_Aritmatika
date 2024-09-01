using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationHandler : MonoBehaviour
{
    public Transform xrRig;            // Referensi ke XR Rig atau XR Origin
    public TeleportationProvider teleportationProvider;

    private float initialXRigY; // Posisi Y awal XR Rig

    private void Start()
    {
        if (xrRig == null || teleportationProvider == null)
        {
            Debug.LogError("XR Rig atau TeleportationProvider belum diatur.");
            return;
        }

        // Simpan posisi Y awal XR Rig
        initialXRigY = xrRig.position.y;

        // Daftarkan event handler untuk teleportasi
        teleportationProvider.endLocomotion += OnTeleportComplete;
    }

    private void OnTeleportComplete(LocomotionSystem locomotionSystem)
    {
        // Setelah teleportasi selesai, setel posisi Y XR Rig agar tetap konsisten
        Vector3 currentPosition = xrRig.position;
        xrRig.position = new Vector3(currentPosition.x, initialXRigY, currentPosition.z);

        Debug.Log($"XR Rig Y Position set to: {initialXRigY}");
    }

    private void OnDestroy()
    {
        // Hapus listener saat skrip dihancurkan
        teleportationProvider.endLocomotion -= OnTeleportComplete;
    }
}
