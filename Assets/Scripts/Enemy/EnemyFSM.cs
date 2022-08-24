using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private Animator _animator;
    public Transform RandomPos;
    public Transform prevPos;

    bool isTarget = false;

    LayerMask PlayLayer;
    NavMeshAgent _navMeshAgent;

    float range = 10f;
    Vector3 point;
    public enum State
    {
        Idle,
        Walk,
        Attack
    }


    public State currentState = State.Idle;

    private void Awake()
    {
        prevPos = GetComponent<Transform>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {

        PlayLayer = LayerMask.NameToLayer("Player");

    }

    private void OnEnable()
    {

        Debug.Log("작동됨123");
        StartCoroutine(RandomTarget());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int layerMask = (1 << PlayLayer);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5f, layerMask); // 타켓지정해주는것
        foreach (Collider col in colliders)
        {
            if (col.name == "Enemy")
            {
                continue;
            }
            Debug.Log("타켓찾음");
            isTarget = true;

            RandomPos = col.transform; //
        }

        if (isTarget)
        {
            _navMeshAgent.SetDestination(RandomPos.position);

        }
        float SensingRange = Vector3.Distance(transform.position, RandomPos.position);
        if (SensingRange > 5f) // 범위가 커버리면
        {
            Debug.Log("작동됨?");
            isTarget = false;
            

        }



        //switch (currentState)
        //{
        //    case State.Idle:
        //        Idle();
        //        break;
        //    case State.Walk:
        //        Walk();
        //        break;
        //    case State.Attack:
        //        Attack();
        //        break;


        //}
    }

    //public float FindDistance = 5f;
    //private void Idle()
    //{

    //        float Distance = Vector3.Distance(transform.position, target.transform.position);
    //        if (Distance < FindDistance)
    //        {

    //            currentState = State.Walk;

    //        } 
    //}

    //public float Speed = 2f;
    //public float attackDistance = 1.5f;
    //private void Walk()
    //{
    //    Vector3 MoveVec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    //    Vector3 dir = target.transform.position - transform.position;
    //        dir.Normalize();


    //    _animator.SetBool("Run", MoveVec != Vector3.zero);
    //    transform.LookAt(target.transform);
    //    float distance = Vector3.Distance(transform.position, target.transform.position);
    //    if (distance < attackDistance)
    //    {
    //        currentState = State.Attack;
    //    }

    //}
    //float currentTime;
    //float attackTime = 1f;
    //private void Attack()
    //{
    //        _animator.SetTrigger("Attack");
    //    currentTime += Time.deltaTime;

    //    if(currentTime > attackTime)
    //    {
    //        currentTime = 0f;


    //        float distance = Vector3.Distance(transform.position, target.transform.position);

    //        if(distance >= attackDistance)
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

    IEnumerator RandomTarget()
    {

        while (true)
        {
            

                if (RandomPoint(RandomPos.position, range, out point))
                {
                    RandomPos.position = point;
                    
                }
                Debug.DrawRay(RandomPos.position, Vector3.up, Color.blue, 6f);
                _navMeshAgent.SetDestination(RandomPos.position);
                yield return new WaitForSeconds(3f);

                yield return null;
           

        }
    }

}
