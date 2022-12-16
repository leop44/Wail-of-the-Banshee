using UnityEngine;

public class Selected : MonoBehaviour
{
    LayerMask mask;
    float distance = 5f;
    public Animator door;
    private bool activeDoor;
    public GameObject textDetectE;
    public GameObject textDetectF;
    private bool lookInt;

    private void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        textDetectE.SetActive(false);
        lookInt = false;
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, mask))
        {
            lookInt = true;
            if (hit.collider.tag == "Interactable")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<TakeObj>().Deactivate();
                }
            }

            if (hit.collider.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    activeDoor = !activeDoor;
                    if (activeDoor == true) door.SetBool("activateDoor", true);
                    if (activeDoor == false) door.SetBool("activateDoor", false);
                }
            }
        }
        else lookInt = false;
    }


    private void OnGUI()
    {
        if (lookInt == true)
        {
            textDetectE.SetActive(true); 
        }
        else
        {
            textDetectE.SetActive(false);
        }
    }
}


