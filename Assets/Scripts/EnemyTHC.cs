using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTHC : MonoBehaviour
{
    public float thcHP = 100;
    public Animator thcAnim;
    bool thcIsDead;

    

    void Start()
    {
        thcHP = 100;
    }


    void Update()
    {
        if (thcHP <= 0)
        {
            thcIsDead = true;
        }

        if (thcIsDead == true)
        {
            thcAnim.SetBool("isDead", true);
            StartCoroutine(Destroy());
        }
        else
        {
            //hareket kodu
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

    void damageReceivedAKM()
    {
        thcHP -= 10;
    }
    void damageReceivedMP7()
    {
        thcHP -= 10;
    }
    void damageReceivedMCX()
    {
        thcHP -= 10;
    }
}

