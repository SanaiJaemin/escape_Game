using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sensing : MonoBehaviour
{
    private float distance = 5f;
    public GameObject Sensou;
   
    public TextMeshProUGUI _textMeshProGUI;
    // Start is called before the first frame update
    void Start()
    {
        Sensou.SetActive(false);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    Raycasting();
    }
    

    void Raycasting()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            void NameInfo(string name)
            {
                if (hit.collider.CompareTag(name))
                {
                    Sensou.SetActive(true);
                    _textMeshProGUI.text = $"[{hit.transform.name}]";
                    
                }
            }
            void tagInfo(string name)
            {
                if (hit.collider.CompareTag(name))
                {
                    Sensou.SetActive(true);
                    _textMeshProGUI.text = $"[{hit.transform.tag}]";

                }
            }  
            NameInfo("Swich"); 
            NameInfo("KeyPad");
            tagInfo("Box");
            if(hit.collider.CompareTag("Item"))
            {

            }
            
        }
        else
        {
            Sensou.SetActive(false);
            
        }

    }
}
