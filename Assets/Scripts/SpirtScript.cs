using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpirtScript : MonoBehaviour {

    public Collider Checkbox;
    public GameObject player;
    bool go = false;

    public Transform target;

    // Speed in units per sec.
    public float speed;
    // Use this for initialization
    void Start ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("You very alone?  you want dance?");
            Debug.Log("Dance 1 Initiated");
            StartCoroutine(Wait());
        }
    }
  // Update is called once per frame
  void Update ()
    {
        if (go == true)
        {
            float step = speed * Time.deltaTime;
            
            // Move our position a step closer to the target.
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            Debug.Log("Follow, Follow");

        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10);
        go = true;
        StopCoroutine(Wait());
    }
}
