using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

    // The target marker.
    public Transform target;
    
    // Speed in units per sec.
    public float speed;
    public float Movespeed = 2;

    public bool Follow = true;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spirit")
        {
            Debug.Log("Sooo... Happy");
            speed = 0;
            StartCoroutine(Wait());
            Follow = false;
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
        yield return new WaitForSecondsRealtime(5);
        speed = Movespeed;
        Follow = true;
        StopCoroutine(Wait());
    }

}
