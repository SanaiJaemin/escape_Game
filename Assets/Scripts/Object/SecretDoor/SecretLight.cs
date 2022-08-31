using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecretLight : MonoBehaviour
{
   public NumberInput _numberInput;
  public GameObject Light;
    public GameObject _trigger;
    // Start is called before the first frame update
    private void Awake()
    {
        _numberInput.Clear = false;
    }
    void Start()
    {
        Light = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
       if(_numberInput.Clear == true)
        {
            Debug.Log($"{_numberInput.Clear}");
            
            Light.GetComponent<MeshRenderer>().material.color = Color.green;
            _trigger.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
