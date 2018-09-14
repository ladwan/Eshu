using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempoScript : MonoBehaviour {

    public Canvas TempoCanvas;
   public int BeatsPerMeasure;
     RawImage Vignette;
    Color alphacolor;
    public int CurrentDance = 1, CPUDance = 10,FailTick,ScoreTick;
    public Text CompareText,FailText,ScoreText;
    GameObject GameOverPanel;
    bool GameisOver;
    public GameObject Sprirt1REF;
    bool DanceStartedREF;
    public GameObject PlayerREF;
    public Text DanceToCopy;
   
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

        if (DanceStartedREF == true)
        {
            DanceToCopy.enabled = true;
        }
        else
        {
            DanceToCopy.enabled = false;
        }

        DanceStartedREF = PlayerREF.GetComponent<playercontrol>().DanceStarted;
        if (GameisOver == true)
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
        if (DanceStartedREF == false)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (CurrentDance == CPUDance)
                {
                    CompareText.text = "Correct";
                    ScoreTick += 10;
                    // Debug.Log("Correct");
                }
                else
                {
                    CompareText.text = "Fail";
                    FailTick++;
                    //Debug.Log("Fail");

                }

            }
        }

        Vignette.color = alphacolor;
    }

    IEnumerator Beat()
    {
        

        yield return new WaitForSecondsRealtime(0.5f);
        CurrentDance = 1;
        DanceToCopy.fontSize = 50;

        BeatsPerMeasure++;
        alphacolor.a = 0.2f;
        Invoke("TurnOffVignette", 0.1f);
        if (DanceStartedREF == true)
        {


            if (BeatsPerMeasure == 2)
            {
                StartCoroutine(Sprirt1REF.GetComponent<Spirit1>().PreDance());
            }
        }

        if (BeatsPerMeasure >= 4)
        {

            StartCoroutine(Sprirt1REF.GetComponent<Spirit1>().Dance());
            DanceToCopy.fontSize = 75;
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
