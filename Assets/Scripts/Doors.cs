using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator door;

    public void Awake()
    {
        door.SetBool("activateDoor", false);
    }


    public void OpenDoor() 
    {
        door.SetBool("activateDoor", true);
    }

    public void CloseDoor() 
    {
        door.SetBool("activateDoor", false);
    }
}
