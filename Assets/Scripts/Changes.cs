using UnityEngine;

public class Changes : MonoBehaviour
{

    public void Temp()
    {
        Invoke("DebugTest", 4);
    }

    void DebugTest() 
    {
        Debug.Log("Messi que mas aplauda le traigo le traigo le traigo la BANSHEE");
    }
}
