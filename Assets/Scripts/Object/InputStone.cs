using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStone : MonoBehaviour
{


    
    public bool[] getStone = new bool[4];
    Dictionary<int,string> StoneTable = new Dictionary<int, string>();
    private GameObject[] StoneInput = new GameObject[4];

    private void Awake()
    {
        StoneTable.Add(0,"RedStone");
        StoneTable.Add(1,"YellowStone");
        StoneTable.Add(2,"BlueStone");
        StoneTable.Add(3,"AquaStoneStone");
        for (int i = 0; i < 4; i++)
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

        for(int i = 0; i < 4; i ++)
        {
            if (other.name == StoneTable[i])
            {
                getStone[i] = true;

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
