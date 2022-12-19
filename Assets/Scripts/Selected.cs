using UnityEngine;

public class Selected : MonoBehaviour
{
    [Header("RayCast")]
    LayerMask mask;
    float distance = 10f;

    [Header("Door")]
    public Animator door;
    private bool activeDoor;

    [Header("Interactable Text")]
    public GameObject textDetectE;
    public GameObject textDetectF;
    private bool lookInt;

    [Header("Chalk")]
    static public bool getChalk;
    public GameObject chalkUI;
    public GameObject pentagramOn;
    public GameObject pentagramOff;

    private void Awake()
    {
        chalkUI.SetActive(false);
        pentagramOff.SetActive(true);
        pentagramOn.SetActive(false);
    }

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
            if (hit.collider.tag == "PowerBank")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<TakeObj>().Deactivate();
                }
            }

            if (hit.collider.tag == "Chalk")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<TakeChalk>().Deactivate();
                }
            }

            if (getChalk == true)
            {
                chalkUI.SetActive(true);
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

            if (hit.collider.tag == "Pentagram")
            {
                if (Input.GetKeyDown(KeyCode.E) && getChalk == true)
                {
                    pentagramOff.SetActive(false);
                    pentagramOn.SetActive(true);
                    chalkUI.SetActive(false);
                    getChalk = false;
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



