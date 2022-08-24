using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject GetObject;
    public GameObject WorldObject;


    LayerMask WorldLayer;

    private bool catching = false;
    private float distance = 5f;
    private void Awake()
    {
        GetObject = GetComponent<GameObject>();
        WorldObject = GetComponent<GameObject>();

    }

    private void Start()
    {
        WorldLayer = LayerMask.NameToLayer("WorldObject");
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        int layerMask1 = (1 << WorldLayer);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5f, layerMask1); // 타켓지정해주는것
        foreach (Collider col in colliders)
        {
            if (col.name == "Main Camera")
            {
                continue;
            }
            
            WorldObject = col.transform.gameObject;

        }

        UpdateInput(); // 키입력
       
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (catching)
            {
                OffCatch();

            }else
            {
            raycasting();

            }

        }

    }

    void raycasting()
    {

        RaycastHit hit;
        

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            Debug.Log(hit.transform.gameObject);

            if(hit.rigidbody && hit.transform.CompareTag("Item"))
            {
            GetObject = hit.transform.gameObject; //히트된 오브젝트 받아옴
            GetObject.transform.parent = gameObject.transform;  //카메라 하위로 들어감
            GetObject.GetComponent<Rigidbody>().useGravity = false;
            GetObject.GetComponent<Rigidbody>().isKinematic = true;
                catching = true;
                StartCoroutine(PositionUpdate());
            }
            if (hit.collider.CompareTag("VisibleDoorOpenSwich"))
            {
                hit.transform.GetComponent<HideZoneSwich>().SwichOn = true;

            }









        }


    }

    void OffCatch()// 놓기
    {
        StopAllCoroutines();
        GetObject.transform.parent = WorldObject.transform;
        Debug.Log("동작잘됨?");
        // 큐/*브를 월드하위로 집어넣음 물건 놓기
        GetObject.GetComponent<Rigidbody>().useGravity = true;
        GetObject.GetComponent<Rigidbody>().isKinematic = false;
        WorldObject.transform.DetachChildren();
        catching = false;


    }



    IEnumerator PositionUpdate()
    {
        while (true)
        {
            yield return null;

            WorldObject.transform.position = GetObject.transform.position;


        }
    }
}
