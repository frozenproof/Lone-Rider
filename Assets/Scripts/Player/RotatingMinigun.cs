using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotatingMinigun : MonoBehaviour
{
    public GameObject MinigunMain;
    public GameObject []MinigunBarrel;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotateMinigunMain());
        StartCoroutine(rotateMinigunBarrel());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public IEnumerator rotateMinigunMain()
    {
        while (true)
        {
            MinigunMain.transform.Rotate(0.0f, 0.0f, 6f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }
    public IEnumerator rotateMinigunBarrel()
    {
        while (true)
        {
            for(int i=0;i<MinigunBarrel.Length;i++)
            {
                MinigunBarrel[i].transform.Rotate(4.0f, 0.0f, 0f, Space.Self);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
