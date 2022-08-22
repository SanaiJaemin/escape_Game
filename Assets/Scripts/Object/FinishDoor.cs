using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoor : MonoBehaviour
{


    public bool GetPlayer = false;

    Vector3 EndPos;
    Vector3 StartPos;
    public GameObject Wall;


    public AudioClip DoorSound;


    private AudioSource _audioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        EndPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GetPlayer)
        {

            StartCoroutine(DoorOpen());
            transform.position = Vector3.Lerp(transform.position, EndPos, Time.deltaTime);
        }
        else
        {

            StartCoroutine(DoorClose());
            transform.position = Vector3.Lerp(transform.position, StartPos, Time.deltaTime);
        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _audioSource.PlayOneShot(DoorSound);
            Debug.Log("¹®¿­¸²");
            GetPlayer = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {


        if (other.tag == "Player")
        {

            Debug.Log("¹®´ÝÈû");
            GetPlayer = false;

        }


    }

    IEnumerator DoorOpen()
    {



        yield return new WaitForSeconds(0.5f);
        Wall.GetComponent<BoxCollider>().isTrigger = true;

    }

    IEnumerator DoorClose()
    {


        yield return new WaitForSeconds(0.5f);
        Wall.GetComponent<BoxCollider>().isTrigger = false;
    }

}
