using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour
{
    public static bool isCannonActive = true;
    public GameObject SakuraCannonR, SakuraCannonL;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveCannon());
    }
    public IEnumerator moveCannon()
    {
        while (true)
        {
            if (isCannonActive)
            {
                while (SakuraCannonR.transform.localRotation.eulerAngles.y > 2)
                {
                    SakuraCannonR.transform.Rotate(0, -1f, 0);
                    SakuraCannonL.transform.Rotate(0, 1f, 0);
                    //Debug.Log("Turning On : " + SakuraCannonR.transform.localRotation.eulerAngles.y);
                    yield return new WaitForSeconds(0.02f);
                }
            }

            if (!isCannonActive)
            {
                while (SakuraCannonR.transform.localRotation.eulerAngles.y < 90)
                {
                    SakuraCannonR.transform.Rotate(0, 1f, 0);
                    SakuraCannonL.transform.Rotate(0, -1f, 0);
                    //Debug.Log("Turning Off : " + SakuraCannonR.transform.localRotation.eulerAngles.y);
                    yield return new WaitForSeconds(0.02f);
                }
            }
            yield return null;
        }
    }
}
