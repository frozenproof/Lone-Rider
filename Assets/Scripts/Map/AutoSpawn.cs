using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        for(int j  = 0; j < 10;j+=4)
        {
            for (int i = 4; i < 2 * 4; i += 4)
            {
                Instantiate(boss, new Vector3(i, 10, 20+j), Quaternion.identity);
            }

            for (int i = 4; i < 2 * 4; i += 4)
            {
                Instantiate(boss, new Vector3(-i, 10, 20+j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
