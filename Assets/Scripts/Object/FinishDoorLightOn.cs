using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoorLightOn : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
   
   private GameObject[] Stone = new GameObject[4];
    // Start is called before the first frame update
    private void Awake()
    {
      for(int i = 0; i < 4; i++)
        {
            Stone[i] = transform.GetChild(i).gameObject;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {


            if (_inputStone.getStone[i] == true)
            {
                
                Stone[i].GetComponent<MeshRenderer>().material.color = Color.red;
                Debug.Log("·¹µå½ºÅæ");
            }
        }
    }
}
