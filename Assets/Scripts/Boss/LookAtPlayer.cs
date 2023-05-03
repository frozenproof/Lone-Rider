using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player, boss, topBody, bossEye;
    private Quaternion _lookRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = boss.GetComponent<Rigidbody>();
        StartCoroutine(rotateTop());
    }

    // Update is called once per frame
    void Update()
    {
        bossEye.transform.LookAt(player.transform);
    }

    public IEnumerator rotateTop()
    {
        while (true)
        {
            _lookRotation = Quaternion.LookRotation(bossEye.transform.forward);
            topBody.transform.rotation = Quaternion.Slerp(topBody.transform.rotation, _lookRotation, 20);
            yield return new WaitForEndOfFrame();
        }
    }
}
