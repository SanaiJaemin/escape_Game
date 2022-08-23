using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform playerPos;
    float TotalTime;
    float range = 10;
    Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        TotalTime += Time.deltaTime;

        if(TotalTime > 10f)
        {
            TotalTime = 0;

            if(RandomPoint(playerPos.position, range,out point))
            {
                playerPos.position = point;
            }
        }
        nav.SetDestination(playerPos.position);
    }

    bool RandomPoint(Vector3 center,float range,out Vector3 result)
    {
        for(int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if(NavMesh.SamplePosition(randomPoint,out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
