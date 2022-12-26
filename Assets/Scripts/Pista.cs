using UnityEngine;

public class Pista : MonoBehaviour
{
    public GameObject pista;



    public void Deactivate()
    {
        pista.SetActive(false);
        Selected.getPista = true;
    }
}
