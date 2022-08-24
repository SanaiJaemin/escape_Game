using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorMove : MonoBehaviour
{


    public Door _door;

    Vector3 EndPos;
    Vector3 StartPos;
 

    private NavMeshObstacle _navMeshObstacle;

    // Start is called before the first frame update
    private void Awake()
    {
        _navMeshObstacle = GetComponent<NavMeshObstacle>();
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        EndPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (_door.GetUnit)
        {
            _navMeshObstacle.carving = false;
            StartCoroutine(DoorOpen());
            transform.position = Vector3.Lerp(transform.position, EndPos, Time.deltaTime);
        }
        else
        {
            _navMeshObstacle.carving = true;
            StartCoroutine(DoorClose());
            transform.position = Vector3.Lerp(transform.position, StartPos, Time.deltaTime);
        }

    }


    IEnumerator DoorOpen()
    {

        yield return new WaitForSeconds(0.5f);
        

    }

    IEnumerator DoorClose()
    {

        yield return new WaitForSeconds(0.5f);
        


    }

}
