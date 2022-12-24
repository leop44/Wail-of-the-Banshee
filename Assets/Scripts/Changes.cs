using UnityEngine;

public class Changes : MonoBehaviour
{
    public float timerScreem = 10f;

    private void Update()
    {
        timerScreem -= Time.deltaTime;
        if (timerScreem <= 0)
        {
            Debug.Log("MESSI SIIIUUU");
            timerScreem = 0;
        }
    }




}
