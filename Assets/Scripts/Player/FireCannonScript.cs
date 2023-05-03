using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireCannonScript : MonoBehaviour
{
    public GameObject SakuraCannonL, SakuraCannonR;
    public GameObject CannonBullet;
    private float power = 8;
    private float cooldown = 0.2f;
    private float tempCooldown;

    // Start is called before the first frame update
    void Start()
    {
        tempCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0)&&CannonScript.isCannonActive)
        {
            tempCooldown -= Time.deltaTime;
            if(tempCooldown <= 0 ) 
            {
                var bulletL = Instantiate(CannonBullet, SakuraCannonL.transform.position + SakuraCannonL.transform.forward * 2, SakuraCannonL.transform.rotation);
                var bulletR = Instantiate(CannonBullet, SakuraCannonR.transform.position + SakuraCannonR.transform.forward * 2, SakuraCannonR.transform.rotation);

                var rigidbodyL = bulletL.GetComponent<Rigidbody>();
                var rigidbodyR = bulletR.GetComponent<Rigidbody>();
                rigidbodyL.velocity = (SakuraCannonL.transform.forward * power * 10);
                rigidbodyR.velocity = (SakuraCannonR.transform.forward * power * 10);
                tempCooldown = cooldown;
            }
        }
    }
}
