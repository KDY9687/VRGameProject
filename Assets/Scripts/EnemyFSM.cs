using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    // Start is called before the first frame update
    //상태변수
    enum EnemyState
    {
        Move,
        Attack,
        Damaged,
        Die
    }

    //상태변수
    EnemyState m_State;

    // 트랜스폼
    Transform player;

    //공격가능 범위
    public float attackDistance;

    //이동속도
    public float moveSpeed;

    // enemy 공격력
    public int attackFower;

    // 누적시간
    float currentTime = 0;

    float moveTime = 5f;

    //공격 딜레이 시간
    float attackDelay = 2f;

    // enemy 체력
    public int hp = 10;

    float birthTime = 0;

    //초기위치
    Vector3 originPos;

    //에니메이터 변수
    Animator anim;

 
    public void HitEnemy(int attackFower)
    {
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die)
        {
            return;
        }
        //피깍기
        hp -= attackFower;
        if (hp > 0)
        {
            m_State = EnemyState.Damaged;
            Damaged();
        }
        else
        {
            m_State = EnemyState.Die;
            Die();
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "bullet") // 총알 피격시 오브젝트 삭제
        {
            Debug.Log("총 맞음");
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(coll.gameObject);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            m_State = EnemyState.Die;
            Die();
        }
    }

    void Move()
    {
        //(x1-x2)^2 + (y1-y2)^2
        float Dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.position.x, 2) + Mathf.Pow(transform.position.z - player.position.z, 2));
        if (Dist > attackDistance)
        {
            //이동 방향 설정
            Vector3 dir = new Vector3(player.position.x - transform.position.x,
                0, player.position.z - transform.position.z).normalized;
            transform.forward = dir;
            //캐릭터 컨트롤러를 이용해 이동하기
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            //print(Vector3.Distance(transform.position, player.position));
        }
        //그렇지 않으면 현재상태를 공격으로 전환한다.
        else
        {
            //현재상태를 공격으로 전환

            m_State = EnemyState.Attack;

            //누적 시간을 공격 딜리이 시간만큼 미리 진행시켜 놓는다.
            currentTime = attackDelay;
            anim.SetTrigger("MoveToDelay");
        }
    }

    void Attack()
    {
        float Dist = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.position.x, 2) + Mathf.Pow(transform.position.z - player.position.z, 2));
        if (Dist < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                //공격 
                //player.GetComponent<Player>().DamageAction(attackFower);
                currentTime = 0;
                //공격 애니메이션 플레이
                anim.SetTrigger("DelayToAttack");
                Debug.Log("attack");
            }
        }
        //그렇지 않으면 현재상태를 이동으로 전환한다.
        else
        {
            //현재상태를 이동으로 전환
            m_State = EnemyState.Move;

            currentTime = 0;
        }
    }

    void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    // 데미지 처리용 코루틴 함수
    IEnumerator DamageProcess()
    {
        //피격 모션 시간만큼 기다린다.
        yield return new WaitForSeconds(0.5f);

        m_State = EnemyState.Die;
        Die();
    }
    void Die()
    {
        StopAllCoroutines();


        StartCoroutine(DieProcess());
    }
    IEnumerator DieProcess()
    {
        anim.SetTrigger("Die");
        
        //피격 모션 시간만큼 기다린다.
        yield return new WaitForSeconds(2f);
        
        Destroy(gameObject);
    }

    void Start()
    {

        originPos = transform.position;
        //에너미 최초상태
        m_State = EnemyState.Move;

        //
        anim = transform.GetComponentInChildren<Animator>();

        player = GameObject.Find("OVRPlayerController").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        birthTime += Time.deltaTime;
        switch (m_State)
        {
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Damaged:
                //Damaged();
                break;
            case EnemyState.Die:
                //Die();
                break;
        }
    }
}
