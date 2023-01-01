using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggers : MonoBehaviour
{
    public bool attak;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="player")
        {
            other.transform.parent.GetComponent<movment>().enemyManager = transform.parent.gameObject;
            other.transform.parent.GetComponent<movment>().attackPos = transform;
            other.transform.parent.GetComponent<movment>().isAttack = true;
            for (int i = 2; i < transform.parent.childCount; i++)
            {
                transform.parent.GetChild(i).GetComponent<Animator>().SetTrigger("isAttack");
                transform.parent.GetChild(i).LookAt(other.transform.parent);
            }

            attak = true;
            
        }
    }

}
