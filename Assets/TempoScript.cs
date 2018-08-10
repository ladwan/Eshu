using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoScript : MonoBehaviour {

    public Canvas TempoCanvas;
    int BeatsPerMeasure;
     RawImage Vignette;
    Color alphacolor;
   
	// Use this for initialization
	void Start ()
    {
        Vignette = TempoCanvas.transform.GetChild(0).GetComponent<RawImage>();
    
        StartCoroutine(Beat());
        alphacolor.a = 0;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vignette.color = alphacolor;
    }

    IEnumerator Beat()
    {
        

        yield return new WaitForSecondsRealtime(0.5f);
        BeatsPerMeasure++;
        alphacolor.a = 0.2f;
        Invoke("TurnOffVignette", 0.1f);

        if (BeatsPerMeasure >= 4)
        {
            alphacolor.a = 0.75f;
            //Debug.Log("Beat");
            BeatsPerMeasure = 0;

        }

        //Debug.Log(BeatsPerMeasure + "dot");
        StartCoroutine(Beat());

    }

    void TurnOffVignette()
    {
        alphacolor.a = 0;
    }
}
