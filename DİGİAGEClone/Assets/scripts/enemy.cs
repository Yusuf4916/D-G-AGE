using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.parent.GetChild(1).GetComponent<triggers>().attak)
        {
            rb.isKinematic = false;
            rb.velocity = transform.forward * 5;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            other.transform.GetComponentInParent<addPlayer>().playerCountText.text = (other.transform.parent.childCount - 2).ToString();

        }
    }


}
