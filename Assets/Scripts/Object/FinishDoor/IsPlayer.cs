using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayer : MonoBehaviour
{
    public FinishDoor _finishDoor;
    public AudioClip DoorSound;
   
    [HideInInspector] public bool isInPlayer = false;
    
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_finishDoor.AllLightOn == true)
        {

            if (other.CompareTag("Player"))
            {
                _audioSource.PlayOneShot(DoorSound);
                isInPlayer = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_finishDoor.AllLightOn == true)
        {

            if (other.CompareTag("Player"))
            {
                _audioSource.PlayOneShot(DoorSound);
                isInPlayer = false;
            }
        }
    }

}
