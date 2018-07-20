using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour {

    // The target marker.
    public Transform target;
    
    // Speed in units per sec.
    public float speed;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Spirit")
        {
            Debug.Log("Sooo... Happy");
            speed = 0;
        }
    }
    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
