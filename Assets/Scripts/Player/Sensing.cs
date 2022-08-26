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
            if (hit.collider.CompareTag("Item"))
            {
                Sensou.SetActive(true);
                _textMeshProGUI.text = hit.transform.name;
            }




            if (hit.collider.CompareTag("Swich"))
            {
                Debug.Log("¾ÈµÊ");
                Sensou.SetActive(true);
                _textMeshProGUI.text = hit.transform.name;

            }
            
              
            



        }
        else
        {
            Sensou.SetActive(false);
            
        }

    }
}
