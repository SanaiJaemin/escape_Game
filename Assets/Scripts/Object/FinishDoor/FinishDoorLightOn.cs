using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDoorLightOn : MonoBehaviour
{

    private MeshRenderer _meshRenderer;
    public InputStone _inputStone;
   private GameObject[] Stone = new GameObject[3];
    public bool[] LightOn = new bool[3];
    
    // Start is called before the first frame update
    private void Awake()
    {


      for(int i = 0; i < 3; i++)
        {
            Stone[i] = transform.GetChild(i).gameObject;
            LightOn[i] = false;
        }
    }

    void Start()
    {
        

    }

    private void OnEnable()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {


            if (_inputStone.getStone[i] == true)
            {

                Stone[i].GetComponent<MeshRenderer>().material.color = Color.green;
                LightOn[i] = true;

            }
           
               
            
        }
        
    
    }
}
