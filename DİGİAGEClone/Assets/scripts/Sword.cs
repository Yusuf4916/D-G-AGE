using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool attack;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "player")
        {
            if (attack)
            {
                Destroy(other.gameObject);
            }

        }
    }




}
