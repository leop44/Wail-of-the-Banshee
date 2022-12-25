using UnityEngine;

public class CallPhone : MonoBehaviour
{
    public GameObject table;
    public GameObject phone;
    public GameObject tone;

    private void Awake()
    {
        table.SetActive(false);
        phone.SetActive(false);
        tone.SetActive(false);
    }

    private void Update()
    {
        if (Selected.llamadaActiva) 
        {
        tone.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && CollisionPhone.callPhone == true)
        {
            table.SetActive(true);
            phone.SetActive(true);
            tone.SetActive(true);
        }
    }
}
