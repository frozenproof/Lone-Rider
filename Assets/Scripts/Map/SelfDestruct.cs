using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimerDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-5)
            Destroy(gameObject);
    }

    public IEnumerator TimerDestroy()
    {
        yield return new WaitForSeconds(10f);
        if(gameObject != null )
        Destroy(gameObject);
    }

    public IEnumerator CollideDestroy()
    {
        yield return new WaitForSeconds(1f);
        if(gameObject != null )
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject != null)
        {
            StartCoroutine(CollideDestroy());
        }
    }
}
