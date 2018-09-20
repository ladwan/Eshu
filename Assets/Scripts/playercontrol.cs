using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

    // The target marker.
    public Transform target;
    public Transform target2;


    // Speed in units per sec.
    public float speed;
    public float Movespeed = 2;
    public bool DanceStarted = false;
    public bool DanceStarted2 = false;
    bool doonce;

    public bool Follow = true;
    public GameObject Spirit1REF, CameraREF;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spirit")
        {
            Debug.Log("Sooo... Happy");
            speed = 0;
            StartCoroutine(Wait());
            Follow = false;
            DanceStarted = true;
        }
    }
    void Update()
    {

        if (DanceStarted2 && doonce == false)
        {
            doonce = true;
            StartCoroutine(Wait());
        }

        if(DanceStarted2 == false)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

            transform.LookAt(targetPosition);
        }
        else
        {
            Vector3 targetPosition2 = new Vector3(target2.transform.position.x, transform.position.y, target2.transform.position.z);

            transform.LookAt(targetPosition2);
        }
        // The step size is equal to speed times frame time.

        if (Follow == true && DanceStarted2 == false)
        {
            speed = Movespeed;
            float step = speed * Time.deltaTime;


            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (Follow == true && DanceStarted2 == true)
        {
            speed = Movespeed;
            float step = speed * Time.deltaTime;


            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }

    }

    IEnumerator Wait()
    {
        CameraREF.GetComponent<CameraFollow>().now = true;
        yield return new WaitForSecondsRealtime(15);
        speed = Movespeed;
        Follow = true;
        DanceStarted = false;
        CameraREF.GetComponent<CameraFollow>().now = false;

        StopCoroutine(Wait());
    }

}
