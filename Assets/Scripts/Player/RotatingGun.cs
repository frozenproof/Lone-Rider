using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingGun : MonoBehaviour
{
    public GameObject Barrel; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(rotateBarrel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator rotateBarrel()
    {
        while(true)
        {
            if(CannonScript.isCannonActive)
            Barrel.transform.Rotate(0.0f, 0.0f, 6f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }
}
