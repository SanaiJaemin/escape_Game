using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    // Start is called before the first frame update

    
    public GameObject GetObject;
    
    public GameObject WorldObject;
    public Material _material;

    bool catching = false;
    private float distance = 3f;
    private void Awake()
    {
        
         GetObject = GetComponent<GameObject>();
        WorldObject = GetComponent<GameObject>();
        _material = GetComponent<Material>();


    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateInput(); // 키입력
        
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            catching = !catching;
            
            if (catching)
            {
                Catchraycasting();
               

            }
            else
            {

                OffCatch();
            }

            
        }
       
    }

    void Catchraycasting()
    {
        
        RaycastHit hit;
        int layerMask = ~(1 << 6);

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            Debug.Log(hit.transform.gameObject);
            MeshRenderer meshRenderer = hit.transform.gameObject.GetComponent<MeshRenderer>();
            
            if(hit.transform.gameObject == null)
            {
                return;
            }

       
            if(hit.collider.CompareTag("VisibleDoorOpenSwich"))
            {
                hit.transform.GetComponent<HideZoneSwich>().SwichOn = true;

                
            }


            if (hit.rigidbody == true)
            { 
                GetObject = hit.transform.gameObject; //히트된 오브젝트 받아옴
            GetObject.transform.parent = gameObject.transform; //카메라 하위로 들어감
            WorldObject.transform.position = GetObject.transform.position; //히트된오브젝트 포지션을 바깥에 저장할오브젝트 포지션에 저장

             
            
            GetObject.GetComponent<Rigidbody>().useGravity = false;
            GetObject.GetComponent<Rigidbody>().isKinematic = true;

            }
            

        }


    }
    

   
   //카메라 하위로 집어넣음 Getobject는 큐브  game은 카메라 World는 좌표저장 문제점 월드도 카메라로 같이들어가버림
    

    void OffCatch()// 안잡을때
    {
         //월드 옵젝좌표로 집어넣음
        GetObject.transform.parent = WorldObject.transform;// 큐브를 월드하위로 집어넣음 물건 놓기
        GetObject.GetComponent<Rigidbody>().useGravity = true;
        GetObject.GetComponent<Rigidbody>().isKinematic = false;
        WorldObject.transform.DetachChildren();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WorldObject"))
        {
            WorldObject = other.gameObject;
        }
    }

}
