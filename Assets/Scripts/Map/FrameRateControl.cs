
using UnityEngine;

public class FrameRateControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 2;
        Application.targetFrameRate = 55;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
