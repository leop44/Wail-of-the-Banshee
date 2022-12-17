using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    static public bool getChalk;

    public GameObject chalkUI;

    private void Awake()
    {
        chalkUI.SetActive(false);
    }
    private void Update()
    {
        if (getChalk == true) 
        {
        chalkUI.SetActive(true);
        }
    }
}
