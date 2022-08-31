using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStone : MonoBehaviour
{


    
    public bool[] getStone = new bool[3];
    Dictionary<int,string> StoneTable = new Dictionary<int, string>();
    private GameObject[] StoneInput = new GameObject[3];
    private AudioSource _audioSource;
    public AudioClip LightSound;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        StoneTable.Add(0,"RedStone");
        StoneTable.Add(1,"YellowStone");
        StoneTable.Add(2,"BlueStone");
       
        for (int i = 0; i < 3; i++)
        {
            StoneInput[i] = transform.GetChild(i).gameObject;
        }

    }




    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {

        for(int i = 0; i < 3; i ++)
        {
            if (other.name == StoneTable[i])
            {
                getStone[i] = true;
                _audioSource.PlayOneShot(LightSound);
            }
        }
        

       
    }

    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < 4; i++)
        {
            if (other.name == StoneTable[i])
            {
                getStone[i] = false;

            }
        }
    }
}
