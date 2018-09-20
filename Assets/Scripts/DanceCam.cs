using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceCam : MonoBehaviour {

    public GameObject CameraREF, Dance1Cam;

	// Use this for initialization
	void Start () {
        CameraREF.transform.position = Dance1Cam.transform.position;
        CameraREF.transform.rotation = Dance1Cam.transform.rotation;

    }

    // Update is called once per frame
    void Update () {
		
	}
}
