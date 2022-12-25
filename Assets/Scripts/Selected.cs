using System;
using UnityEngine;

public class Selected : MonoBehaviour
{
    private SoundManager soundManager;

    [Header("RayCast")]
    LayerMask mask;
    float distance = 10f;
    public GameObject cursor;
    public GameObject cursor2;
    private bool lookInt;

    [Header("Chalk")]
    static public bool getChalk;
    public GameObject chalkUI;

    public GameObject chalk;

    bool puedeMorir;
    public bool conditionWin01 = false;
    public bool conditionWin02 = false;
    static public bool canWin = false;

    [Header("Ring")]
    static public bool getRing;

    [Header("Pista")]
    static public bool getPista;
    public GameObject pista;
    public bool lookPista;

    static public bool llamadaActiva = false;






    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        chalkUI.SetActive(false);
        cursor2.SetActive(false);
    }

    private void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        lookInt = false;
        getPista = false;
        lookPista = false;
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
                    getChalk = true;
                    puedeMorir = true;
                    conditionWin01 = true;
                    chalk.SetActive(false);
                }
            }

            if (hit.collider.tag == "Pista")
            {
                if (Input.GetKeyUp(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<Pista>().Deactivate();
                }
            }


            if (hit.collider.tag == "Ring")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<GetRing>().Deactivate();
                }
            }

            if (getChalk == true)
            {
                chalkUI.SetActive(true);
            }

            if (hit.collider.tag == "Door") { }

            if (hit.collider.tag == "Messi") 
            {
                if (Input.GetKeyDown(KeyCode.E)) 
                {
                    soundManager.SeleccionAudio(5, 0.7f);
                    llamadaActiva = true;
                }
            }

        }
        else lookInt = false;

        if (getPista == true)
        {
            pista.SetActive(true);
            lookPista = true;
        }

        if (Input.GetKeyDown(KeyCode.E) && lookPista == true)
        {
            pista.SetActive(false);
            getPista = false;
        }

        if (puedeMorir == true) 
        {
            soundManager.SeleccionAudio(1, 0.9f);
            puedeMorir = false;
        }

        if (conditionWin01 == true && conditionWin02 == true) 
        {
            canWin = true;
        }

        if (Pentagram.pentagramActive == true) conditionWin02 = true;
    }


    private void OnGUI()
    {
        if (lookInt == true)
        {
            cursor2.SetActive(true);
            cursor.SetActive(false);
        }
        else
        {
            cursor2.SetActive(false);
            cursor.SetActive(true);
        }
    }
}



