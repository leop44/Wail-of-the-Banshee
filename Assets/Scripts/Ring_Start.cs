using UnityEngine;
using UnityEngine.Events;

public class Ring_Start : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;
    public float timerScreem = 5f;
    bool timerCheck;
    public GameObject screamer;
    private SoundManager soundManager;

    private void Awake()
    {
        timerCheck = false;
        screamer.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (timerCheck == true) 
        {
            Timer();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Selected.getRing == true) 
        {
            onTrigger.Invoke();
            Debug.Log("Messi que mas aplauda le traigo le traigo le traigo la BANSHEE");
            timerCheck = true;
        }
    }

    void Timer() 
    {
        timerScreem -= Time.deltaTime;
        if (timerScreem <= 0)
        {
            screamer.SetActive(true);
            soundManager.SeleccionAudio(0, 1f);
            timerScreem = 0;
            timerCheck = false;
        }
    }

}
