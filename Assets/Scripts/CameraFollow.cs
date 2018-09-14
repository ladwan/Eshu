
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target, target2;
    public Vector3 offset;
    public float smoothspeed = 0.125f;
    public bool now = false;
    public GameObject PlayerREF,SpiritREF;
    public bool DanceBegunREF;
    public int GamePhase = 1;

    private void LateUpdate()
    {
        DanceBegunREF = PlayerREF.GetComponent<playercontrol>().DanceStarted;

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition,smoothspeed);
        transform.position = smoothedPosition;

        if (SpiritREF.GetComponent<SpirtScript>().Dance1Complete == true)
        {
            GamePhase = 2;
        }

        transform.LookAt(target);
        if (GamePhase == 2)
        {
            offset = new Vector3(8, 5, 7);


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
            offset = new Vector3(-8, 6, 5);
        }
        /* else
        {
            offset = new Vector3(4, 4, 5);
        } */
    } 
}
