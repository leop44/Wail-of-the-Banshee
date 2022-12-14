using UnityEngine;
using TMPro;

public class PhoneLight : MonoBehaviour
{
    public Light phoneLight;
    private bool activeLight;
    private float amountBattery = 100f;
    private float batteryLoss = 10f;
    public GameObject objLight;

    

    [Header("Visuals")]
    public TextMeshProUGUI percentage;
    public GameObject fullCharge;
    public GameObject needCharge;



    private void Start()
    {
        objLight.SetActive(true);
        fullCharge.SetActive(true);

    }
    private void Update()
    {
        amountBattery = Mathf.Clamp(amountBattery, 0, 100);
        int batteryValue = (int)amountBattery;
        percentage.text = batteryValue.ToString();

        if (Input.GetKeyDown(KeyCode.F) && amountBattery > 0)
        {
            activeLight = !activeLight;

            if (activeLight == true) phoneLight.enabled = true;

            if (activeLight == false) phoneLight.enabled = false;
        }

        if (activeLight == true && amountBattery > 0) 
        {
            amountBattery -= batteryLoss * Time.deltaTime;
        }

        if (amountBattery >= 0 && amountBattery <= 20) 
        {
            fullCharge.SetActive(false);
            needCharge.SetActive(true);
        }
        
        if(amountBattery == 0) objLight.SetActive(false);



    }
}
