using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossEnemy : MonoBehaviour
{
    [SerializeField]private int health;
    public TextMeshPro healhtText;
    public GameObject sword;

    private void Start()
    {
        health = Random.Range(20, 30);
    }
    private void Update()
    {

        healhtText.text = health.ToString();
        if (health <= 0)
            Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            health--;
            Destroy(other.gameObject);

        }
    }
    public void trueAttack()
    {
        sword.GetComponent<Sword>().attack = true;
    }
    public void falseAttack()
    {
        sword.GetComponent<Sword>().attack = false;
    }
}
