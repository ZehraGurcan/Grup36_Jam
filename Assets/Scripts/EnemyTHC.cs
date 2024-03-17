using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTHC : MonoBehaviour
{
    public float THCHP = 100;
    public Animator THCAnim;
    bool THCIsDead;

    GameObject target;
    public float chasingDistance;
    public float attackDistance;
    NavMeshAgent THCNavMesh;
    float distance;

    void Start()
    {
        THCHP = 100;
        target = GameObject.Find("Oyuncu");
        THCNavMesh = this.GetComponent<NavMeshAgent>();
    }


    void Update()
    {

        this.transform.LookAt(target.transform.position);
        if (THCHP <= 0)
        {
            THCIsDead = true;
        }

        if (THCIsDead == true)
        {
            THCAnim.SetBool("isDead", true);
            THCNavMesh.isStopped = true;
            StartCoroutine(Destroy());
        }
        else
        {
            distance = Vector3.Distance(this.transform.position, target.transform.position);

            if (distance < chasingDistance)
            {
                THCNavMesh.isStopped = false;
                THCNavMesh.SetDestination(target.transform.position);
                THCAnim.SetBool("isWalking", true);
            }
            else
            {
                THCNavMesh.isStopped = true;
                THCAnim.SetBool("isWalking", false);
            }

            if (distance < attackDistance)
            {
                THCNavMesh.isStopped = true;
                THCAnim.SetBool("isAttacking", true);
            }
            else
            {
                THCAnim.SetBool("isAttacking", false);
            }
        }
    }

    void giveDamage()
    {
        target.GetComponent<MovementsFPS>().damageReceivedTHC();
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    public void damageReceivedAKM()
    {
        THCHP -= 10;
    }
    void damageReceivedMP7()
    {
        THCHP -= 10;
    }
    void damageReceivedMCX()
    {
        THCHP -= 10;
    }
}

