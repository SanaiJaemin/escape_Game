using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZone : MonoBehaviour
{
   
    
    GameObject VisibleDoor;
   public bool DoorClose = false;

    Vector3 ClosePosition;

    // Start is called before the first frame update
    void Start()
    {
        ClosePosition = new Vector3(transform.position.x,transform.position.y - 2.5f,transform.position.z);

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Item"))
        {
            DoorClose = true;
        }
    }

}
