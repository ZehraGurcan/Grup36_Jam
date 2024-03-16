using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class EnemyOrk : MonoBehaviour
{
    public float orkHP = 100;
    public Animator orkAnim;
    bool orkIsDead;

    GameObject target;
    public float chasingDistance;
    public float attackDistance;
    NavMeshAgent orkNavMesh;
    float distance;

    void Start()
    {
        orkHP = 100;
        target = GameObject.Find("Oyuncu");
        orkNavMesh = this.GetComponent<NavMeshAgent>();
    }


    void Update()
    {

        this.transform.LookAt(target.transform.position);
        if (orkHP <= 0)
        {
            orkIsDead = true;
        }

        if (orkIsDead == true)
        {
            orkAnim.SetBool("isDead", true);
            StartCoroutine(Destroy());
        }
        else
        {
            distance = Vector3.Distance(this.transform.position, target.transform.position);

            if (distance < chasingDistance)
            {
                orkNavMesh.isStopped = false;
                orkNavMesh.SetDestination(target.transform.position);
                orkAnim.SetBool("isWalking", true);
            }
            else
            {
                orkNavMesh.isStopped = true;
                orkAnim.SetBool("isWalking", false);
            }

            if (distance < attackDistance)
            {
                orkNavMesh.isStopped = true;
                orkAnim.SetBool("isAttacking", true);
            }
            else
            {
                orkAnim.SetBool("isAttacking", false);
            }
        }
    }

    void giveDamage()
    {
        target.GetComponent<MovementsFPS>().damageReceivedOrk();
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    void damageReceivedAKM()
    {
        orkHP -= 10;
    }
    void damageReceivedMP7()
    {
        orkHP -= 10;
    }
    void damageReceivedMCX()
    {
        orkHP -= 10;
    }

    
}
