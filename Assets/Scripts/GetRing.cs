using UnityEngine;

public class GetRing : MonoBehaviour
{
    public GameObject ring;

    public void Deactivate()
    {
        ring.SetActive(false);
        Selected.getRing = true;
    }



}
