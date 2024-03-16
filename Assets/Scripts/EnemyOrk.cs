using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOrk : MonoBehaviour
{
    public float orkHP = 100;
    public Animator orkAnim;
    bool orkIsDead;

    void Start()
    {
        orkHP = 100;
    }


    void Update()
    {
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
