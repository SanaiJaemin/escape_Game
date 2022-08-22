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
        UpdateInput(); // Ű�Է�
        
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
                GetObject = hit.transform.gameObject; //��Ʈ�� ������Ʈ �޾ƿ�
            GetObject.transform.parent = gameObject.transform; //ī�޶� ������ ��
            WorldObject.transform.position = GetObject.transform.position; //��Ʈ�ȿ�����Ʈ �������� �ٱ��� �����ҿ�����Ʈ �����ǿ� ����

             
            
            GetObject.GetComponent<Rigidbody>().useGravity = false;
            GetObject.GetComponent<Rigidbody>().isKinematic = true;

            }
            

        }


    }
    

   
   //ī�޶� ������ ������� Getobject�� ť��  game�� ī�޶� World�� ��ǥ���� ������ ���嵵 ī�޶�� ���̵�����
    

    void OffCatch()// ��������
    {
         //���� ������ǥ�� �������
        GetObject.transform.parent = WorldObject.transform;// ť�긦 ���������� ������� ���� ����
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
