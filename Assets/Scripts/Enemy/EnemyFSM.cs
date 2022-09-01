using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum CurrentState { idle, Run, Attack };
    public CurrentState curState = CurrentState.idle;
    private Animator _animator;
    public Transform TargetPos;


    public GameObject Randomobject;
    public bool isTargetPlayer = false;
    public float TargetRange = 5f;
    public bool PlayerDie = false;
    public float attackDistance = 2f;
    float randomPositionScend = 5f;
    float Delay;
    NavMeshAgent _navMeshAgent;
    float range = 5f;
    Vector3 point;

    private AudioSource _audioSource;
    public AudioClip WalkSound;

    LayerMask PlayLayer; //�÷��̾� ���� ���̾��ũ����
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        PlayLayer = LayerMask.NameToLayer("Player"); //  �÷��̾�ã�ư��Բ� ���̾��̸� �־��ֱ�
        StartCoroutine(StateCheck());
        StartCoroutine(CheckStateForAction());
    }


    IEnumerator StateCheck()
    {
        while (!PlayerDie)
        {
            RandomTarget(); //����Ÿ�� �������� ���� ����
            TargetCollider(); // �÷��̾��
            yield return new WaitForSeconds(0.2f);
            float Dist = Vector3.Distance(transform.position, TargetPos.position);
            if (Dist <= attackDistance && isTargetPlayer == true)
            {
                curState = CurrentState.Attack;
            }
            else if (Dist >= TargetRange && isTargetPlayer == true)
            {

                TargetPos = Randomobject.transform;
                isTargetPlayer = false;
                curState = CurrentState.Run;
            }
            else
            {
                curState = CurrentState.Run;
            }



        }
    }

    IEnumerator CheckStateForAction()
    {
        while (!PlayerDie)
        {
            float Dist = Vector3.Distance(transform.position, TargetPos.position);
            switch (curState)
            {

                case CurrentState.idle:
                    _navMeshAgent.isStopped = true;
                    _navMeshAgent.velocity = Vector3.zero;
                    _animator.SetBool("Run", false);
                    yield return new WaitForSeconds(3f);
                    break;

                case CurrentState.Run:
                    _navMeshAgent.isStopped = false;
                    
                    _animator.SetBool("Run", true);
                    _navMeshAgent.SetDestination(TargetPos.position);
                    if (!isTargetPlayer && Dist <= 0.5f)
                    {
                        curState = CurrentState.idle;
                    }
                    break;

                case CurrentState.Attack:
                    _navMeshAgent.isStopped = true;
                    _animator.SetBool("Attack", true);
                    yield return new WaitForSeconds(2.5f);
                    if (isTargetPlayer)
                    {
                        curState = CurrentState.Run;
                        _animator.SetTrigger("PrevRun");

                    }
                    if (Dist >= attackDistance)
                    {
                        curState = CurrentState.idle;

                    }
                    break;
            }
            yield return null;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RandomTarget();
    }





    private void TargetCollider()
    {
        int layerMask = (1 << PlayLayer);

        Collider[] colliders = Physics.OverlapSphere(this.transform.position, TargetRange, layerMask);
        foreach (Collider col in colliders) // 
        {
            if (col.name == "Enemy")
            {
                continue;
            }
            Debug.Log("Ÿ��ã��");
            isTargetPlayer = true;
            TargetPos = col.transform;
            break;
        }
    } //��Ʈ���ϴٰ� ã��������
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
    bool RandomPoint(Vector3 center, float range, out Vector3 result)  // �߽� , ���� , ���ϰ����
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
}
