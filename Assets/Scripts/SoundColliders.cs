using UnityEngine;

public class SoundColliders : MonoBehaviour
{
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            soundManager.SeleccionAudio(1, 0.8f);
        }
    }
}
