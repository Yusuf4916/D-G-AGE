using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{
    private Rigidbody rb;
    private float firstPos = 0, lastPos;
    [SerializeField] private float velos;
    public bool isAttack,isStart;
    public Transform attackPos;
    public GameObject enemyManager;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (isAttack)
        {
            if (attackPos)
            {
                for (int i = 1; i < transform.childCount; i++)
                {
                    transform.GetChild(i).LookAt(attackPos);
                    transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                    transform.GetChild(i).GetComponent<Rigidbody>().velocity = transform.GetChild(i).forward * 2;
                }
                if (enemyManager.transform.childCount<3)
                {
                    for (int i = 1; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).transform.rotation= Quaternion.Euler(Vector3.zero);
                        transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = true;
                    }
                    isAttack =false;
                    attackPos = null;
                    enemyManager = null;
                    GetComponent<addPlayer>().playerPos();
                }
            }
        }

        else
        {
            singleMovment();
        }
        

    }

    void singleMovment()
    {
        float velo = lastPos - firstPos;

        if (Input.touchCount > 0)
        {
            isStart = true;
            for (int i = 1; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<player>().anim.SetTrigger("isAttack");
            }
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = touch.deltaPosition.x;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                lastPos = touch.deltaPosition.x;
            }
            transform.Translate((Vector3.right * velo / velos * Time.deltaTime));


        }
        if(isStart)
            rb.velocity = Vector3.forward * 10;
    }
}
