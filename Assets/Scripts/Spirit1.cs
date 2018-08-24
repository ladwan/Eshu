using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit1 : MonoBehaviour {
    int DanceToPerform, CpuDance, PlayerDance, PointsToWin;
	// Use this for initialization
	void Start ()
    {


	}
    
	
	// Update is called once per frame
	void Update ()
    {
       DanceToPerform =  Random.Range(1, 5);

        if(PointsToWin >= 5)
        {
            Debug.Log("Amazing");
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            PlayerDance = 1;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            PlayerDance = 2;
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            PlayerDance = 3;
        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            PlayerDance = 4;
        }
    }

    public IEnumerator Dance()
    {
        yield return new WaitForSeconds(0);
        switch (DanceToPerform)
        {
            case 1:
                CpuDance = 1;
                Debug.Log("Watch Me");

                if(PlayerDance == CpuDance)
                {
                    PointsToWin++;
                }
                else
                {
                    Debug.Log("Wrong Move");
                }

                break;

            case 2:
                CpuDance = 2;
                Debug.Log("Look Here");

                if (PlayerDance == CpuDance)
                {
                    PointsToWin++;
                }
                else
                {
                    Debug.Log("Wrong Move");
                }


                break;

            case 3:
                CpuDance = 3;
                Debug.Log("Keep Up");

                if (PlayerDance == CpuDance)
                {
                    PointsToWin++;
                }
                else
                {
                    Debug.Log("Wrong Move");
                }


                break;

            case 4:
                CpuDance = 4;
                Debug.Log("Yes Yes !");

                if (PlayerDance == CpuDance)
                {
                    PointsToWin++;
                }
                else
                {
                    Debug.Log("Wrong Move");
                }


                break;
        }

    }
}
