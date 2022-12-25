using UnityEngine;
using UnityEngine.Events;

public class Ring_Start : MonoBehaviour
{
    [SerializeField] private UnityEvent onTrigger;
    private float timerScreem = 300f;
    private float timerGO = 5f;
    bool timerCheck;
    bool timerCheck02;
    public GameObject screamer;
    private SoundManager soundManager;
    public GameObject gameOver;
    public GameObject buttonGO;

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
        if (timerCheck02 == true) TimerGO();



    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Selected.getRing == true) 
        {
            onTrigger.Invoke();
            timerCheck = true;
            soundManager.SeleccionAudio(4, 0.6f);
        }
    }

    void Timer() 
    {
        timerScreem -= Time.deltaTime;
        if (timerScreem <= 0 && Selected.canWin == false)
        {
            screamer.SetActive(true);
            soundManager.SeleccionAudio(0, 1f);
            timerScreem = 0;
            timerCheck = false;
            timerCheck02 = true;
        }

    }

    void TimerGO() 
    {
        timerGO -= Time.deltaTime;
        if (timerGO <= 0) 
        {
            gameOver.SetActive(true);
            buttonGO.SetActive(true);
            timerGO = 0;
            timerCheck02 = false;
        }
    }

}
