using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody _rigidbody;
    GameObject GetObject;
    public GameObject WorldObject;
    bool catching = false;
    private float distance = 1f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetObject = GetComponent<GameObject>();
        WorldObject = GetComponent<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
       

    }

    private void FixedUpdate()
    {
        UpdateInput(); // Ű�Է�
        
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"{catching}");
            catching = !catching;
            
            if (catching)
            {
                raycasting();
                OnCatch();

            }
            else
            {

                OffCatch();
            }

           


        }
    }

    void raycasting()
    {
        
        RaycastHit hit;
        int layerMask = ~(1 << 6);

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            Debug.Log(hit.transform.gameObject);
            MeshRenderer meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
            GetObject = hit.transform.gameObject;

            
        }


    }
    

    void OnCatch()
    {
        GetObject.transform.parent = gameObject.transform; //ī�޶� ������ �������
    }

    void OffCatch()
    {
        WorldObject.transform.position = GetObject.transform.position; //���� ������ǥ�� �������
        GetObject.transform.parent = gameObject.transform; // 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WorldObject"))
        {
            WorldObject = other.gameObject;
        }
    }

}
