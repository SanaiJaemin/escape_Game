using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private Animator _animator;
    public Transform TargetPos;


    public GameObject Randomobject;
    public bool isTargetPlayer = false;
    public float PlayerTargetRange = 5f;


    float randomPositionScend = 5f;
    float Delay;
    NavMeshAgent _navMeshAgent;

    float range = 10f;
    Vector3 point;
    Vector3 Movevec;

    LayerMask PlayLayer; //플레이어 넣을 레이어마스크공간
    void Start()
    {
        PlayLayer = LayerMask.NameToLayer("Player"); //  플레이어찾아가게끔 레이어이름 넣어주기

    }

    private void Awake()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        RandomTarget(); // 랜덤타겟 패트롤


        Vector3 Movevec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _animator.SetBool("Run", Movevec != Vector3.zero);
        transform.LookAt(TargetPos);

        int layerMask = (1 << PlayLayer); 
        
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, PlayerTargetRange, layerMask);  
        foreach (Collider col in colliders) // 
        {
            if (col.name == "Enemy") 
            {
                continue;
            }
            Debug.Log("타켓찾음");
            isTargetPlayer = true;
            TargetPos = col.transform;
            break;
        }

        if (isTargetPlayer)
        {
            float SensingRange = Vector3.Distance(transform.position, TargetPos.position); 
           
            _navMeshAgent.SetDestination(TargetPos.position);

            if (SensingRange > 2f)
            {

            }

            if (SensingRange > PlayerTargetRange)
            {
                TargetPos = Randomobject.transform;
                _navMeshAgent.SetDestination(TargetPos.position);
                isTargetPlayer = false;

            }
        }


        Debug.Log($"{PlayerTargetRange}");
    }


    public float Speed = 2f;
    public float attackDistance = 1.5f;
    //float attackTime = 1f;
    //private void Attack()
    //{
    //    _animator.SetTrigger("Attack");
    //    Delay += Time.deltaTime;

    //    if (Delay > attackTime)
    //    {
    //        Delay = 0f;

    //        if (Delay >= attackDistance)
    //        {

    //            currentState = State.Walk;
    //        }
    //    }
    //}

    bool RandomPoint(Vector3 center, float range, out Vector3 result)  // 중심 , 범위 , 리턴결과값
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;

            }

        }
        result = Vector3.zero;
        return false;
    }

    public void RandomTarget()
    {
        Debug.Log($"{isTargetPlayer}");
        if (isTargetPlayer)
        {
            return;
        }
        Delay += Time.deltaTime;
        if (Delay > randomPositionScend)
        {
          
            Delay = 0f;
            if (RandomPoint(TargetPos.position, range, out point)) 
            {
                TargetPos.position = point;


            }
            Debug.DrawRay(TargetPos.position, Vector3.up, Color.blue, 6f); 
            
            _navMeshAgent.SetDestination(TargetPos.position); 
           
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("RandomPos"))
        {
            _animator.SetTrigger("Idle");
            Debug.Log("발동됨");
        }
    }

}
