using UnityEngine;
using UnityEngine.Events;

public class Ring_Start : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ring")) 
        {
            onTrigger.Invoke();
            Debug.Log("Messi que mas aplauda le traigo le traigo le traigo la BANSHEE");
        }
    }
}
