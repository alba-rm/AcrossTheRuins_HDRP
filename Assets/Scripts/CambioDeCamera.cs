using UnityEngine;

public class CambioDeCamara : MonoBehaviour
{
    public Camera nuevaCamara; // Arrastra la nueva cámara desde el editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CambiarCamara();
        }
    }

    void CambiarCamara()
    {
        // Desactiva la cámara principal
        Camera.main.gameObject.SetActive(false);

        // Activa la nueva cámara
        nuevaCamara.gameObject.SetActive(true);
    }
}