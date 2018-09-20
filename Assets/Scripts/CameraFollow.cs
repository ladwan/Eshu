using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target, target2;
    public Vector3 offset;
    public float smoothspeed = 0.125f;
    public bool now = false;
    public GameObject PlayerREF,SpiritREF;
    public bool DanceBegunREF;
    public int GamePhase = 1;
    public bool doOnce = false;
    public bool doOnce2 = false;



    private void LateUpdate()
    {
        DanceBegunREF = PlayerREF.GetComponent<playercontrol>().DanceStarted;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothspeed);
        transform.position = smoothedPosition;

        if (SpiritREF.GetComponent<SpirtScript>().Dance1Complete == true && doOnce == false)
        {
            doOnce = true;
            StartCoroutine(Delay());
        }

        //transform.LookAt(target);

        if (GamePhase == 2 && SpiritREF.GetComponent<SpirtScript>().SnapCam == true && doOnce2 == false)
        {
            doOnce2 = true;
            StartCoroutine(Delay2());
        }

        if (now == true)
        {
            transform.LookAt(target2);

        }
        else
        {
            transform.LookAt(target);
        }

        if (DanceBegunREF == true && GamePhase == 1)
        {
            offset = new Vector3(3.2f, 4.04f, -1.24f);
        }
     
    }

    IEnumerator Delay()
    {
        offset = new Vector3(16, 7, 5);

        yield return new WaitForSecondsRealtime (2);

        offset = new Vector3(24, 5, -7);
        GamePhase = 2;
        StopCoroutine(Delay());
    }

    IEnumerator Delay2()
    {
        offset = new Vector3(-37, 7, 5);
        yield return new WaitForSecondsRealtime(2);

        
        
        StopCoroutine(Delay2());
    }


}
