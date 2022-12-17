using UnityEngine;

public class TakeChalk : MonoBehaviour
{
    public GameObject chalk;

    public void Deactivate()
    {
        chalk.SetActive(false);
        Selected.getChalk = true;
    }
}
