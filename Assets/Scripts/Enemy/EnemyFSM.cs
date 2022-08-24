using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    private Animator _animator;
    public Transform RandomPos;
    public Transform Player;
    
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
    // Start is called before the first frame update
    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        
        PlayLayer = LayerMask.NameToLayer("Player");
        
    }

    private void OnEnable()
    {
 
            Debug.Log("¿€µøµ 123");
            StartCoroutine(RandomTarget());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int  layerMask = (1 << PlayLayer);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 5f, layerMask); // ≈∏ƒœ¡ˆ¡§«ÿ¡÷¥¬∞Õ
        foreach(Collider col in colliders)
        {
            if(col.name == "Enemy")
            {
                continue;
            }
            Debug.Log("≈∏ƒœ√£¿Ω");
            RandomPos = col.transform;
            
            _navMeshAgent.SetDestination(RandomPos.position); 
            StopAllCoroutines(); //∑£¥˝¡¬«• ƒ⁄∑Á∆æ∏ÿ√„
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
            if(NavMesh.SamplePosition(randomPoint,out hit,1.0f,NavMesh.AllAreas))
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
        

        while(true)
        {

            if(RandomPoint(RandomPos.position,range,out point))
            {
                RandomPos.position = point;
            }
            _navMeshAgent.SetDestination(RandomPos.position);
            yield return new WaitForSeconds(5f);

            yield return null;
        }
    }

}
