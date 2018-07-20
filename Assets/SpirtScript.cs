using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpirtScript : MonoBehaviour {

    public Collider Checkbox;
    public GameObject player;
    bool go = false;

	// Use this for initialization
	void Start ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("You very alone,  you want dance?");
            StartCoroutine(Wait());
        }
    }
  // Update is called once per frame
  void Update ()
    {
        if (go == true)
        {
            transform.Translate(0, 0 , 2);
            Debug.Log("Follow, Follow");

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5);
        go = true;
    }
}
