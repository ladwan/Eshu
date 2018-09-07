using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spirit1 : MonoBehaviour {

    int DanceToPerform, CpuDance, PlayerDance, PointsToWin, BeatsREF, RandomREF;
    public Text MoveToCopy;
    public Animator Anim;
    bool DanceREf;
    public GameObject PlayerREF;


	// Use this for initialization
	void Start ()
    {
       

    }
    
	
	// Update is called once per frame
	void Update ()
    {
  
        DanceREf = PlayerREF.GetComponent<playercontrol>().DanceStarted;
        MoveToCopy.text = CpuDance.ToString();
       DanceToPerform =  Random.Range(1, 5);
        
 

        if(PointsToWin >= 5)
        {
            Debug.Log("Amazing");
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            PlayerDance = 1;
            Debug.Log("dude");
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            PlayerDance = 2;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            PlayerDance = 3;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            PlayerDance = 4;
        }
    }

    public IEnumerator Dance()
    {
       
        if (DanceREf == true)
        {


            yield return new WaitForSeconds(0);
            switch (RandomREF)
            {
                case 1:
                   
                

                    if (PlayerDance == CpuDance)
                    {
                        PointsToWin++;
                        PlayerREF.GetComponent<TempoScript>().ScoreTick += 10;
                    }
                    else
                    {
                        Debug.Log("Wrong Move");
                        PlayerREF.GetComponent<TempoScript>().FailTick++;

                    }

                    break;

                case 2:
                  

                    if (PlayerDance == CpuDance)
                    {

                        PointsToWin++;
                        PlayerREF.GetComponent<TempoScript>().ScoreTick += 10;

                    }
                    else
                    {
                        Debug.Log("Wrong Move");
                        PlayerREF.GetComponent<TempoScript>().FailTick++;

                    }


                    break;

                case 3:
                  
            

                    if (PlayerDance == CpuDance)
                    {
                        PointsToWin++;
                        PlayerREF.GetComponent<TempoScript>().ScoreTick += 10;

                    }
                    else
                    {
                        Debug.Log("Wrong Move");
                        PlayerREF.GetComponent<TempoScript>().FailTick++;

                    }


                    break;

                case 4:
                
            
                    if (PlayerDance == CpuDance)
                    {
                        PointsToWin++;
                        PlayerREF.GetComponent<TempoScript>().ScoreTick += 10;

                    }
                    else
                    {
                        Debug.Log("Wrong Move");
                        PlayerREF.GetComponent<TempoScript>().FailTick++;

                    }


                    break;
            }
        }

    }

    public IEnumerator PreDance()
    {
        RandomREF = DanceToPerform;


        yield return new WaitForSeconds(0);
        switch (RandomREF)
        {
            case 1:
                CpuDance = 1;
                Anim.SetTrigger("IsTilt1");
                Debug.Log("Watch Me");

               

                break;

            case 2:
                CpuDance = 2;
                Anim.SetTrigger("IsTilt2");

                Debug.Log("Look Here");


                break;

            case 3:
                CpuDance = 3;
                Anim.SetTrigger("IsTilt3");

                Debug.Log("Keep Up");

              
                break;

            case 4:
                CpuDance = 4;
                Anim.SetTrigger("IsTilt4");

             


                break;
        }

    }
}
