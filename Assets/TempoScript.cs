﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempoScript : MonoBehaviour {

    public Canvas TempoCanvas;
    int BeatsPerMeasure;
     RawImage Vignette;
    Color alphacolor;
    int CurrentDance = 1, CPUDance = 10,FailTick,ScoreTick;
    public Text CompareText,FailText,ScoreText;
    GameObject GameOverPanel;
    bool GameisOver;
    
   
	// Use this for initialization
	void Start ()
    {
        GameOverPanel = GameObject.Find("GameOver");
        GameOverPanel.SetActive(false);

        Vignette = TempoCanvas.transform.GetChild(0).GetComponent<RawImage>();
    
        StartCoroutine(Beat());
        alphacolor.a = 0;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(GameisOver == true)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }

        FailText.text = FailTick.ToString();
        ScoreText.text = ScoreTick.ToString();
        if (FailTick >= 3)
        {
            GameOverPanel.SetActive(true);
            GameisOver = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (CurrentDance == CPUDance)
            {
                CompareText.text = "Correct";
                ScoreTick += 10 ;
               // Debug.Log("Correct");
            }
            else
            {
                CompareText.text = "Fail";
                FailTick++;
                //Debug.Log("Fail");

            }

        }


        Vignette.color = alphacolor;
    }

    IEnumerator Beat()
    {
        

        yield return new WaitForSecondsRealtime(0.5f);
        CurrentDance = 1;
        BeatsPerMeasure++;
        alphacolor.a = 0.2f;
        Invoke("TurnOffVignette", 0.1f);

        if (BeatsPerMeasure >= 4)
        {
            CurrentDance = 10;
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
