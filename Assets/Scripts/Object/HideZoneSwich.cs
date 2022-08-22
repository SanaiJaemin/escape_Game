using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideZoneSwich : MonoBehaviour
{
    // Start is called before the first frame update
    public bool SwichOn = false;
  
    private Renderer _renderer;
    private void Awake()
    {
        
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!SwichOn)
        {
            _renderer.material.color = Color.red;
        }
        else
        {
            _renderer.material.color = Color.green;
        }
    }
}
