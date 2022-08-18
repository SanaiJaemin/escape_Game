using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            raycasting();
        }
    }

    void raycasting()
    {   
        float distance = 20f;
        Vector3 EndPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        
        RaycastHit hit;

        int layerMask = ~(1 << 6);
        Debug.DrawLine(transform.position,transform.forward * 200f, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            Debug.Log(hit.transform.gameObject);
            MeshRenderer meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
        
            if(meshRenderer.material.color == Color.white)
            {
                meshRenderer.material.color = Color.red;
            }
        
        }
        

    }
        void OnDrawGizmos()
        {
        
        float distance = 20f;
        Vector3 EndPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + distance);
        Ray ray = Camera.main.ScreenPointToRay(transform.forward);
            Gizmos.color = Color.blue;
            Gizmos.DrawRay(ray);
        }

}
