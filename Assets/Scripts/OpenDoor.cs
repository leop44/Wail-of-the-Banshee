using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool doorOpen;
    public bool canOpen = false;
    public float doorAngle = 100f;
    public float doorCloseAngle = 0f;
    public float smooth = 3f;


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
        }
        else if (Input.GetKeyDown(KeyCode.E) && canOpen == true && doorOpen == true)
        {
            doorOpen = false;
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
