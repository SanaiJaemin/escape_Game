using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody _rigidbody;
   public GameObject GetObject;
   public GameObject prevObject;
    public GameObject WorldObject;

    bool catching = false;
    private float distance = 3f;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetObject = GetComponent<GameObject>();
        WorldObject = GetComponent<GameObject>();
        prevObject = GetComponent<GameObject>();
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
                raycasting();
               

            }
            else
            {

                OffCatch();
            }

            Debug.Log($"{catching}");
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
            GetObject = hit.transform.gameObject; //��Ʈ�� ������Ʈ �޾ƿ�
            GetObject.transform.parent = gameObject.transform; //ī�޶� ������ ��
            WorldObject.transform.position = GetObject.transform.position; //��Ʈ�ȿ�����Ʈ �������� �ٱ��� �����ҿ�����Ʈ �����ǿ� ����
            GetObject.GetComponent<Rigidbody>().useGravity = false; 
            GetObject.GetComponent<Rigidbody>().isKinematic = true;

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
