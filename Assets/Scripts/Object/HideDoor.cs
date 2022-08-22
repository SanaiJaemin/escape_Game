using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDoor : MonoBehaviour
{
    float DoorSpeed = 0.3f;
   public HideZone _hideZone;
    Vector3 ClosePosition;
    Vector3 StartPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ClosePosition = new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_hideZone.DoorClose)
        {

            transform.position = Vector3.Lerp(transform.position, StartPosition, Time.deltaTime * DoorSpeed);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, ClosePosition, Time.deltaTime * DoorSpeed);
        }


    }

    

   


  
    

}
