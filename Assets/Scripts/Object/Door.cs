using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
   public AudioClip DoorSound;
    private AudioSource _audioSource;

    public bool GetUnit = false;

    // Start is called before the first frame update

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

    }

  



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Enemy")
        {
            _audioSource.PlayOneShot(DoorSound);
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
