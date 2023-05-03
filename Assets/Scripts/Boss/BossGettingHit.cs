using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGettingHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("yesh : "+ collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Hit");
            DamageCalc.score += 1;
        }
    }
}
