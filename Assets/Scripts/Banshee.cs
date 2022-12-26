using UnityEngine;
using UnityEngine.AI;

public class Banshee : MonoBehaviour
{
    [SerializeField] Transform[] wayPoints;
    public float speedBanshee;
    public float runSpeedBanshee;
    float distanceCambio = 10f;
    int numberNetxPosition;
    public Animator ani;
    public GameObject target;





    private void Start()
    {
        numberNetxPosition = Random.Range(0, wayPoints.Length-1);
        ani = GetComponent<Animator>();
        target = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[numberNetxPosition].position, speedBanshee * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoints[numberNetxPosition].position) < distanceCambio) 
        {
            numberNetxPosition = Random.Range(0, wayPoints.Length-1);
            ani.SetBool("walk", true);
            ani.SetBool("run", false);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player")) 
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, runSpeedBanshee * Time.deltaTime);
        }
    }
}
