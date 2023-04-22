using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region ENUM
    enum State
    {
        NONE,
        IDLE,
        MOVE,
        ATTACK,
        STUN,
        DYING
    }
    #endregion

    #region FIELDS SERIALIZED

    [Title("Resources")]
    [SerializeField]
    private Transform models;

    [Title("HitBoxes")]
    [SerializeField]
    private HitBox[] HitBoxesHead;
    [SerializeField]
    private HitBox[] HitBoxesBody;
    [SerializeField]
    private HitBox[] HitBoxesOther;

    [Title("States")]
    [SerializeField]
    private float hp;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float attackSpeed;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackDMG;
    [SerializeField]
    private State nowState;

    #endregion

    #region Field
    private State nextState;

    private Vector3 targetPosition;
    private Vector3 dir;
    private Barricade targetAttack;

    private bool animDone;

    private Animator animator;

    private ScoreAndItem sysScore;
    #endregion

    #region UNITY
    public void Start()
    {
        InitHitBoxes();
        InitModels();
        animator = GetComponent<Animator>();
        animDone = true;
        nowState = State.NONE;
        nextState = State.IDLE;
    }

    public void Update()
    {
        //State function 
        if (nextState == State.NONE)
        {
            switch (nowState)
            {
                case State.IDLE:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 7, QueryTriggerInteraction.Ignore))
                    {
                        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange, 1 << 7, QueryTriggerInteraction.Ignore);
                        targetAttack = colliders[0].GetComponent<Barricade>();
                        nextState = State.ATTACK;
                    }
                    else
                    {
                        nextState = State.MOVE;
                    }
                    break;
                case State.MOVE:
                    if (Physics.CheckSphere(transform.position, attackRange, 1 << 7, QueryTriggerInteraction.Ignore))
                    {
                        Collider[] colliders = Physics.OverlapSphere(this.transform.position, attackRange, 1 << 7, QueryTriggerInteraction.Ignore);
                        targetAttack = colliders[0].GetComponent<Barricade>();
                        nextState = State.ATTACK;
                    }
                    else
                    {
                        dir = targetPosition - transform.position;
                        dir.y = 0;
                        dir.Normalize();
                        transform.rotation = Quaternion.LookRotation(dir);
                        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
                    }
                    break;
                case State.ATTACK:
                    if (animDone)
                    {
                        nextState = State.IDLE;
                        animDone = false;
                    }
                    break;
                case State.STUN:
                    if (animDone)
                    {
                        nextState = State.IDLE;
                        animDone = false;
                    }
                    break;
                case State.DYING:
                    if (animDone)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        //Change State
        if (nextState != State.NONE)
        {
            nowState = nextState;
            nextState = State.NONE;
            switch (nowState)
            {
                case State.IDLE:
                    Idel();
                    break;
                case State.MOVE:
                    Move();
                    break;
                case State.ATTACK:
                    Attack();
                    break;
                case State.STUN:
                    Stun();
                    break;
                case State.DYING:
                    Dying();
                    break;
            }
        }

    }

    public void OnDestroy()
    {
        if (sysScore == null) sysScore = GameObject.FindGameObjectWithTag("Sys").GetComponent<ScoreAndItem>();
        sysScore.EnemyDie();
    }

    public void WhenAnimationDone()
    {
        animDone = true;
    }

    public void AttackBarricade()
    {
        targetAttack.GetDmg(attackDMG);
    }

    private void OnDrawGizmosSelected() //Debug
    {
        Gizmos.color = new UnityEngine.Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);
    }
    #endregion

    #region METHODS
    private void InitHitBoxes()
    {
        foreach (var hitBox in HitBoxesHead)
            hitBox.Init(this, 0);

        foreach (var hitBox in HitBoxesBody)
            hitBox.Init(this, 1);

        foreach (var hitBox in HitBoxesOther)
            hitBox.Init(this);
    }
    private void InitModels()
    {
        int rand = Random.Range(0, models.childCount);
        for (int i = 0; i< models.childCount; i++)
        {
            if (i == rand) models.GetChild(i).gameObject.SetActive(true);
            else Destroy(models.GetChild(i).gameObject);
        }

    }

    public void GetDmg(float dmg, bool isStunBullet)
    {
        if (nowState == State.DYING) return;

        hp -= dmg;
        if (hp <= 0) nextState = State.DYING;
        else if (isStunBullet) nextState = State.STUN;
    }

    private void OffAnimBool()
    {
        animator.SetBool("attack", false);
        animator.SetBool("walk", false);
        animator.SetBool("idle", false);
        animator.SetBool("stun", false);
        animator.SetBool("die", false);
    }
    private void Attack()
    {
        OffAnimBool();
        animator.SetBool("attack", true);
    }
    private void Move()
    {
        OffAnimBool();
        animator.SetBool("walk", true);
    }
    private void Idel()
    {
        OffAnimBool();
        animator.SetBool("idle", true);
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    }
    private void Stun()
    {
        OffAnimBool();
        animator.SetBool("stun", true);
        animDone = false;
    }
    private void Dying()
    {
        animDone = false;
        OffAnimBool();
        animator.SetBool("die", true);
    }

    #endregion
}
