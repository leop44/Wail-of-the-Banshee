using UnityEngine;

public class TakeObj : MonoBehaviour
{
    public GameObject pB;


    public void Deactivate()
    {
        pB.SetActive(false);
        PhoneLight.getPB = true;
    }
}
