using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private Animator _animator;
    public Transform target;
    bool Target = false;
    LayerMask PlayLayer;
    public enum State
    {
        Idle,
        Walk,
        Attack
    }

    WaitForSeconds Delay100 = new WaitForSeconds(1f);
    public State currentState = State.Idle;
    // Start is called before the first frame update
    private void Awake()
    {
        target = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        target = null;
        PlayLayer = LayerMask.NameToLayer("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int  layerMask = (1 << PlayLayer);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10f, layerMask);
        foreach(Collider col in colliders)
        {
            if(col.name == "Enemy")
            {
                continue;
            }
            target = col.transform;
        }

        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.Walk:
                Walk();
                break;
            case State.Attack:
                Attack();
                break;


        }
    }

    public float FindDistance = 5f;
    private void Idle()
    {

            float Distance = Vector3.Distance(transform.position, target.transform.position);
            if (Distance < FindDistance)
            {

                currentState = State.Walk;

            } 
    }

    public float Speed = 2f;
    public float attackDistance = 1.5f;
    private void Walk()
    {
        Vector3 MoveVec = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Vector3 dir = target.transform.position - transform.position;
            dir.Normalize();
        
        transform.position += dir * Speed * Time.deltaTime; // 플레이어로 이동
        _animator.SetBool("Run", MoveVec != Vector3.zero);
        transform.LookAt(target.transform);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < attackDistance)
        {
            currentState = State.Attack;
        }

    }
    float currentTime;
    float attackTime = 1f;
    private void Attack()
    {
            _animator.SetTrigger("Attack");
        currentTime += Time.deltaTime;
        
        if(currentTime > attackTime)
        {
            currentTime = 0f;

            
            float distance = Vector3.Distance(transform.position, target.transform.position);

            if(distance >= attackDistance)
            {
                
                currentState = State.Walk;
            }
        }
    }

   

}
