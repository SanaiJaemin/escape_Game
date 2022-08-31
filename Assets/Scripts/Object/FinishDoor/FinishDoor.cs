using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{


    Vector3 EndPos;
    Vector3 StartPos;
    public FinishDoorLightOn Clear;
    public IsPlayer _isPlayer;
    public bool AllLightOn = false;

    // Start is called before the first frame update
    private void Awake()
    { 
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        EndPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

    }
 
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Clear.LightOn[0] == true && Clear.LightOn[1] == true && Clear.LightOn[2] == true)
        {
           AllLightOn = true;
            if (_isPlayer.isInPlayer == true)
            {
               
                transform.position = Vector3.Lerp(transform.position, EndPos, Time.deltaTime);
            }
            else
            {
                
                transform.position = Vector3.Lerp(transform.position, StartPos, Time.deltaTime);
            }
        }



    }

   

}
