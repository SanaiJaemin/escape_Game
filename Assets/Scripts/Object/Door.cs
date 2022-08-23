using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
 

    public bool GetUnit = false;

    // Start is called before the first frame update
  
    

   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
        {
            
            GetUnit = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {


        if (other.tag =="Player" || other.tag == "Enemy")
        {
            
            
            GetUnit = false;

        }


    }

    

}
