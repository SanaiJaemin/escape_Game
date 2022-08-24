using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sensing : MonoBehaviour
{
    private float distance = 5f;
    public GameObject Sensou;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Raycasting();
    }

    void Raycasting()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position,transform.forward,out hit,distance))
        {
            if(hit.collider.CompareTag("Item"))
            {
                Sensou.SetActive(true);
            }
            else
            {
                Sensou.SetActive(false);
            }
            
            
            if(hit.collider.CompareTag("VisibleDoorOpenSwich"))
            {
                Debug.Log("¾ÈµÊ");
                button.SetActive(true);

            }
            else
            {
                button.SetActive(false);
            }
            
            
            
        }
    }
}
