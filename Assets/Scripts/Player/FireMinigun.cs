using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireMinigun : MonoBehaviour
{
    public GameObject minigun1,minigun2,minigun3;
    public GameObject bullet;
    private float power = 8;
    private float cooldown = 0.2f;
    private float tempCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            tempCooldown -= Time.deltaTime;
            if (tempCooldown <= 0)
            {
                var bullet1 = Instantiate(bullet, minigun1.transform.position + minigun1.transform.forward * 2, minigun1.transform.rotation);
                var rigidbody1 = bullet1.GetComponent<Rigidbody>();
                rigidbody1.velocity = (minigun1.transform.forward * power * 10);

                var bullet2 = Instantiate(bullet, minigun2.transform.position + minigun2.transform.forward * 2, minigun2.transform.rotation);
                var rigidbody2 = bullet2.GetComponent<Rigidbody>();
                rigidbody2.velocity = (minigun2.transform.forward * power * 10);

                var bullet3 = Instantiate(bullet, minigun3.transform.position + minigun3.transform.forward * 2, minigun3.transform.rotation);
                var rigidbody3 = bullet3.GetComponent<Rigidbody>();
                rigidbody3.velocity = (minigun3.transform.forward * power * 10);
               
                tempCooldown = cooldown;
            }
        }
    }

}
