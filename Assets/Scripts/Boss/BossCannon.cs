using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannon : MonoBehaviour
{
    public GameObject player, bulletCannon, topBody;
    private float power = 8;
    float cooldown = 1f;
    float tempCooldown;
    // Start is called before the first frame update
    void Start()
    {
        tempCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            tempCooldown -= Time.deltaTime;
            if (tempCooldown < 0)
            {
                StartCoroutine(fireCannon());
                tempCooldown = cooldown;
            }
        }
    }

    public IEnumerator fireCannon()
    {
        var bulletC = Instantiate(bulletCannon,transform.position,topBody.transform.rotation);
        var rigidbody = bulletC.GetComponent<Rigidbody>();
        rigidbody.velocity = (topBody.transform.forward * power * 10);
        yield return new WaitForEndOfFrame();
    }
}
