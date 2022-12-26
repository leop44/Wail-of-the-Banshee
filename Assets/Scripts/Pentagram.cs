using UnityEngine;

public class Pentagram : MonoBehaviour
{
    public GameObject pentagramOn;
    public GameObject pentagramOff;
    static public bool pentagramActive = false;
    bool timerActive = false;
    float timer = 2f;
    public GameObject win;


    private void Awake()
    {
        pentagramOff.SetActive(true);
        pentagramOn.SetActive(false);
    }

    private void Update()
    {
        if(timerActive == true) Timer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Selected.getChalk == true) 
        {
            pentagramOff.SetActive(false);
            pentagramOn.SetActive(true);
            pentagramActive = true;
            timerActive = true;
        }
    }

    void Timer()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            win.SetActive(true);
            timer = 0;
        }

    }
}
