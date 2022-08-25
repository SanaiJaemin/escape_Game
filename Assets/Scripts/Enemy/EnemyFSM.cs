using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private Animator _animator;
    public Transform TargetPos;


    public GameObject Randomobject;
    bool isTargetPlayer = false;


    float randomPositionScend = 5f;
    float Delay;
    LayerMask PlayLayer;
    NavMeshAgent _navMeshAgent;

    float range = 10f;
    Vector3 point;
    Vector3 Movevec;


    private void Awake()
    {

        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        PlayLayer = LayerMask.NameToLayer("Player");

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = (1 << PlayLayer);

        RandomTarget(); // 랜덤타겟 패트롤


        Vector3 Movevec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        _animator.SetBool("Run", Movevec != Vector3.zero);
        transform.LookAt(TargetPos);
        
       

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5f, layerMask); // 타켓지정해주는것
        foreach (Collider col in colliders)
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

            // 플레이어 와 몬스터 거리가 공격범위가 5 이상이면 추격중지 하고 랜덤오브젝트 좌표로 타겟포지션 지정
            if (SensingRange > 5f)
            {
                TargetPos = Randomobject.transform;
                _navMeshAgent.SetDestination(TargetPos.position);
                isTargetPlayer = false;

            }
        }

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

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
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
            if (RandomPoint(TargetPos.position, range, out point)) //랜덤 포지션
            {
                TargetPos.position = point;


            }
            Debug.DrawRay(TargetPos.position, Vector3.up, Color.blue, 6f);
            
            _navMeshAgent.SetDestination(TargetPos.position); // 타겟따라가게하기
           
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
