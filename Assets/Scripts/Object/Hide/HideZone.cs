using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZone : MonoBehaviour
{

    AudioClip VisibleDoorSound;
    AudioSource _audioSource;
    public EnemyFSM _Enemyfsm;
    
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
        if(DoorClose)
        {
            _Enemyfsm.isTargetPlayer = false;
            _Enemyfsm.TargetRange = 1f;

        }
        else
        {
            _Enemyfsm.TargetRange = 5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(VisibleDoorSound);
            DoorClose = true;
            Debug.Log("¿€µøµ ");
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
