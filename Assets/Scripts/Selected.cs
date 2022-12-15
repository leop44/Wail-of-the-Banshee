using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    [SerializeField] float distance = 1.5f;
    public Animator door;
    private bool doorZone;

    private void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        doorZone = false;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask)) 
        {
            if (hit.collider.tag == "Interactable") 
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    hit.collider.transform.GetComponent<TakeObj>().Deactivate();
                }
            }
            if (hit.collider.tag == "Door") 
            {
                doorZone = true;
            }
            if (Input.GetKeyDown(KeyCode.T)) 
            {
                if (doorZone == true) door.SetBool("activateDoor", true);
                if (doorZone == false) door.SetBool("activateDoor", false);
            }
        }
    }
}


