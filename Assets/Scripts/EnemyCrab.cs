using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCrab : MonoBehaviour
{
    public float crabHP = 100;
    public Animator crabAnim;
    bool crabIsDead;

    GameObject target;
    public float chasingDistance;
    public float attackDistance;
    NavMeshAgent crabNavMesh;
    float distance;

    void Start()
    {
        crabHP = 100;
        target = GameObject.Find("Oyuncu");
        crabNavMesh = this.GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {

        this.transform.LookAt(target.transform.position);
        if(crabHP <= 0)
        {
            crabIsDead = true;
        }

        if(crabIsDead == true)
        {
            crabAnim.SetBool("isDead",true);
            crabNavMesh.isStopped = true;
            StartCoroutine(Destroy());
        }
        else
        {
            distance = Vector3.Distance(this.transform.position , target.transform.position);

            if(distance < chasingDistance)
            {
                crabNavMesh.isStopped = false;
                crabNavMesh.SetDestination(target.transform.position);
                crabAnim.SetBool("isWalking", true);
            }
            else
            {
                crabNavMesh.isStopped = true;
                crabAnim.SetBool("isWalking", false);
            }

            if(distance < attackDistance)
            {
                crabNavMesh.isStopped = true;
                crabAnim.SetBool("isAttacking", true);
            }
            else
            {
                crabAnim.SetBool("isAttacking", false);
            }
        }
    }

    void giveDamage()
    {
        target.GetComponent<MovementsFPS>().damageReceivedCrab();
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    public void damageReceivedAKM()
    {
        crabHP -= 10;
    }
    void damageReceivedMP7()
    {
        crabHP -= 10;
    }
    void damageReceivedMCX()
    {
        crabHP -= 10;
    }
}
