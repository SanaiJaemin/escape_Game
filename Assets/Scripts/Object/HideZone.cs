using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZone : MonoBehaviour
{

    AudioClip VisibleDoorSound;
    AudioSource _audioSource;
    
   public bool DoorClose = false;


    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(VisibleDoorSound);
            DoorClose = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //if (other.CompareTag("Player"))
        //{
        //    DoorClose = false;
        //}
    }
}
