using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if(transform.parent.GetComponent<movment>().isStart)
            anim.SetTrigger("isAttack");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Hammer")
        {
            Destroy(gameObject);
            CountText();
        }
        if (other.gameObject.tag=="Chingsaw")
        {
            Destroy(gameObject);
            CountText();

        }
        if (other.gameObject.tag == "Smash")
        {
            CountText();
            Destroy(gameObject);
        }
    }

   
    void CountText()
    {
        transform.parent.GetComponent<addPlayer>().playerCountText.text = (transform.parent.childCount).ToString();
    }

}
