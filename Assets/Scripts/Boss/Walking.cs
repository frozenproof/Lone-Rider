using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public GameObject leftLeg, rightLeg;
    public GameObject leftLowerLeg, rightLowerLeg;
    public GameObject topBody, bottomBody, mainBody;
    public GameObject bossEye;
    float speedBoss = 1f;
    // Start is called before the first frame update
    //x y z inspector
    //rotate x,z,y khi dung euler ????
    //a hinh nhu la boi vi pivot sai vi tri :v

    //Animation handmade(By QTuan :3)
    //
    //

    void Start()
    {
        //Debug.Log("Goc x bth:"+leftLeg.transform.localRotation.x);
        //Debug.Log("Goc x euler:" + leftLeg.transform.localRotation.eulerAngles.x);
        StartCoroutine(ForwardLeftLeg());
    }

    // Update is called once per frame
    void Update()
    {
        //rightLeg.transform.Rotate(1f, 0f, 0f, Space.Self);
        //Debug.Log(rightLeg.transform.localRotation.x);
    }

    public IEnumerator ForwardLeftLeg()
    {
        StartCoroutine(Move60LeftUpper());
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator ForwardRightLeg()
    {
        StartCoroutine(Move60RightUpper());
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator Move60LeftUpper()
    {
        while (leftLeg.transform.localRotation.x > -0.5)
        {
            leftLeg.transform.Rotate(-1f, 0f, 0f, Space.Self);
            leftLowerLeg.transform.Rotate(0f, 0f, -1f, Space.Self);
            //Debug.Log("Moving:" + leftLeg.transform.localRotation.x);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(MoveBodyForward());
        StartCoroutine(StraightLowerLeftLeg());
        //Right leg to backward
        while (rightLeg.transform.localRotation.x < 0.25)
        {
            //move right leg backward
            rightLeg.transform.Rotate(1f, 0f, 0f, Space.Self);
            //move right lower leg upward
            rightLowerLeg.transform.Rotate(0f, 0f, -1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(StraightLeftleg());
        //Right leg back to normal
        while (rightLeg.transform.localRotation.x > 0)
        {
            //move right leg upward
            rightLeg.transform.Rotate(-1f, 0f, 0f, Space.Self);
            //move right lower leg backward
            rightLowerLeg.transform.Rotate(0f, 0f, 1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(20f);
        StartCoroutine(ForwardRightLeg());
    }

    public IEnumerator Move60RightUpper()
    {
        while (rightLeg.transform.localRotation.x > -0.5)
        {
            rightLeg.transform.Rotate(-1f, 0f, 0f, Space.Self);
            rightLowerLeg.transform.Rotate(0f, 0f, 1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(MoveBodyForward());
        StartCoroutine(StraightLowerRightLeg());
        //left Leg to backward
        while (leftLeg.transform.localRotation.x < 0.25)
        {
            //move left leg backward
            leftLeg.transform.Rotate(1f, 0f, 0f, Space.Self);
            //move left lower leg backward
            leftLowerLeg.transform.Rotate(0f, 0f, 1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(StraightRightleg());
        //left Leg to normal
        while (leftLeg.transform.localRotation.x > 0)
        {
            //move left leg backward
            leftLeg.transform.Rotate(-1f, 0f, 0f, Space.Self);
            //move left lower leg backward
            leftLowerLeg.transform.Rotate(0f, 0f, -1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(ForwardLeftLeg());
    }

    public IEnumerator MoveBodyForward()
    {
        mainBody.transform.position = mainBody.transform.position + new Vector3(bottomBody.transform.forward.x, 0, bottomBody.transform.forward.z) * speedBoss / 100;
        //mainBody.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speedBoss * 800);
        StartCoroutine(RecalculateDirection());
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator RecalculateDirection()
    {
        float anglebetween = Vector3.SignedAngle(new Vector3(topBody.transform.forward.x, 0, topBody.transform.forward.z), bottomBody.transform.forward, topBody.transform.forward);
        //Debug.Log("Direction: " + new Vector3(topBody.transform.forward.x, 0, topBody.transform.forward.z));
        //while (Math.Abs(anglebetween) > 10)
        if (Math.Abs(anglebetween) > 5)
        {
            if (anglebetween < 0)
                bottomBody.transform.Rotate(0, -0.5f, 0);
            if (anglebetween > 0)
                bottomBody.transform.Rotate(0, 0.5f, 0);

            anglebetween = Vector3.SignedAngle(new Vector3(topBody.transform.forward.x, 0, topBody.transform.forward.z), bottomBody.transform.forward, topBody.transform.forward);
            //Debug.Log("Rotation: " + anglebetween);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();
    }


    public IEnumerator StraightLowerLeftLeg()
    {
        while (leftLowerLeg.transform.localRotation.z < 0)
        {
            StartCoroutine(MoveBodyForward());
            leftLowerLeg.transform.Rotate(0f, 0f, 1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator StraightLeftleg()
    {
        while (leftLeg.transform.localRotation.x < 0)
        {
            StartCoroutine(MoveBodyForward());
            leftLeg.transform.Rotate(1f, 0f, 0f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator StraightLowerRightLeg()
    {
        while (rightLowerLeg.transform.localRotation.z > 0)
        {
            StartCoroutine(MoveBodyForward());
            rightLowerLeg.transform.Rotate(0f, 0f, -1f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator StraightRightleg()
    {
        while (rightLeg.transform.localRotation.x < 0)
        {
            StartCoroutine(MoveBodyForward());
            rightLeg.transform.Rotate(1f, 0f, 0f, Space.Self);
            yield return new WaitForEndOfFrame();
        }
    }
}
