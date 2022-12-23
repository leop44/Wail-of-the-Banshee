using UnityEngine;

public class TakeObj : MonoBehaviour
{
    public GameObject pB;
    public GameObject ring;


    public void Deactivate()
    {
        pB.SetActive(false);
        PhoneLight.getPB = true;
    }

    public void LePrincipio() 
    {
        ring.SetActive(false);
    }
}
