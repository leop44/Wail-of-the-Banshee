using UnityEngine;

public class CollisionPhone : MonoBehaviour
{
    static public bool callPhone = false;


    private void OnTriggerEnter(Collider other)
    {
        callPhone = true;
    }
}
