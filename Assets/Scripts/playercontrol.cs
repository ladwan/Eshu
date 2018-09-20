﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

    // The target marker.
    public Transform target;
    
    // Speed in units per sec.
    public float speed;
    public float Movespeed = 2;
    public bool DanceStarted = false;
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

        Vector3 targetPosition = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);

        transform.LookAt(targetPosition);
        // The step size is equal to speed times frame time.

        if (Follow == true)
        {
            speed = Movespeed;
            float step = speed * Time.deltaTime;


            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

    }

    IEnumerator Wait()
    {
        CameraREF.GetComponent<CameraFollow>().now = true;
        yield return new WaitForSecondsRealtime(10);
        DanceStarted = false;
        yield return new WaitForSecondsRealtime(2);

        speed = Movespeed;
        Follow = true;
        DanceStarted = false;
        CameraREF.GetComponent<CameraFollow>().now = false;

        StopCoroutine(Wait());
    }

}
