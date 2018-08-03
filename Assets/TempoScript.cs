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
        if (Vignette != null)
        {
            Debug.Log("boom bitch");
        }
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
        

        if (BeatsPerMeasure >= 4)
        {
            alphacolor.a = 0.75f;
            Debug.Log("Beat");
            BeatsPerMeasure = 0;

        }

       

        yield return new WaitForSecondsRealtime(0.5f);
        BeatsPerMeasure++;
        alphacolor.a = 0.2f;
        yield return new WaitForSecondsRealtime(0.01f);
        alphacolor.a = 0;


        Debug.Log(BeatsPerMeasure + "dot");
        StartCoroutine(Beat());

    }
}
