using UnityEngine;
using TMPro;

public class PhoneLight : MonoBehaviour
{
    [Header("Logic")]
    public Light phoneLight;
    public bool activeLight;
    public float amountBattery = 100f;
    public float batteryLoss = 1f;
    public GameObject objLight;
    static public bool getPB;

    [Header("Visuals")]
    public TextMeshProUGUI percentage;
    public GameObject fullCharge;
    public GameObject needCharge;

    private void Awake()
    {
        objLight.SetActive(true);
        fullCharge.SetActive(true);

    }

    private void Update()
    {
        var batMax = 100f;
        var batMin = 0f;
        amountBattery = Mathf.Clamp(amountBattery, batMin, batMax);
        int batteryValue = (int)amountBattery;
        percentage.text = batteryValue.ToString();

        if (amountBattery > 0) objLight.SetActive(true);

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

        if (amountBattery == 0) objLight.SetActive(false);

        if (getPB == true)
        {
            amountBattery += 50f;
            getPB = false;
        }
    }
}
