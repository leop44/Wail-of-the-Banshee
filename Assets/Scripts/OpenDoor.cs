using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool doorOpen;
    public bool canOpen = false;
    public float doorAngle = 100f;
    public float doorCloseAngle = 0f;
    public float smooth = 3f;
    private SoundManager soundManager;
    bool soundOpen = false;
    bool soundClose = false;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
    private void Start()
    {
        doorOpen = false;
    }
    private void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E) && canOpen == true && doorOpen == false)
        {
            doorOpen = true;
            soundOpen = true;

        }
        else if (Input.GetKeyDown(KeyCode.E) && canOpen == true && doorOpen == true)
        {
            doorOpen = false;
            soundClose = true;

        }

        if (soundOpen == true) 
        {
            soundManager.SeleccionAudio(2, 0.6f);
            soundOpen = false;
        }

        if (soundClose == true) 
        {
            soundManager.SeleccionAudio(3, 0.6f);
            soundClose = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") canOpen = false;
    }
}
