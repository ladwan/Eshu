using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpirtScript : MonoBehaviour {

    public Collider Checkbox;
    public GameObject player;
    bool go = false;
    public bool Dance1Complete = false;
    public Animator Anim;
    public ParticleSystem FireWorks;
    public Transform target;

    // Speed in units per sec.
    public float speed;
    // Use this for initialization
    void Start ()
    {
        FireWorks.enableEmission = false;
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
        yield return new WaitForSecondsRealtime(8);
        FireWorks.enableEmission = true;

        yield return new WaitForSecondsRealtime(2);
       

        Dance1Complete = true;
        Anim.SetTrigger("IsJump");

        yield return new WaitForSecondsRealtime(2);
        go = true;
        FireWorks.enableEmission = false;
       


        StopCoroutine(Wait());
    }
}
