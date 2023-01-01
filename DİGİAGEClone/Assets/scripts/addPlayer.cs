using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class addPlayer : MonoBehaviour
{
    public GameObject player;
    public TextMeshPro playerCountText;
    private int playerCount;
    [SerializeField] private float distance, radius;
    private void Start()
    {
        playerCount = transform.childCount-1;
        playerCountText.text = playerCount.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="barrier")
        {
            insPlayer(other.gameObject);
        }
    }

    void insPlayer(GameObject barrier)
    {
        int barriers = barrier.GetComponent<Barrier>().chose;

        if (barriers==1)
        {
            for (int i = 0; i < barrier.GetComponent<Barrier>().randomGate; i++)
            {
                Instantiate(player, transform.position, Quaternion.identity, transform);
            }
            playerCount = transform.childCount - 1;
            playerCountText.text = playerCount.ToString();
            playerPos();
        }
        else
        {
            int a = (barrier.GetComponent<Barrier>().randomGate) * (transform.childCount - 1);
            for (int i = 0; i < a; i++)
            {
                Instantiate(player, transform.position, Quaternion.identity, transform);
            }
            playerCount = transform.childCount - 1;
            playerCountText.text = playerCount.ToString();
            playerPos();
        }
        
        
    }

    public void playerPos()
    {
        playerCountText.text = (transform.childCount - 1).ToString();

        for (int i = 1; i < transform.childCount - 1; i++)
        {
            float x = distance * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            float z = distance * Mathf.Sqrt(i) * Mathf.Sin(i * radius);

            Vector3 newPos = new Vector3(x, 0, z);
            transform.GetChild(i).DOLocalMove(newPos, 1).SetEase(Ease.OutBack);
        }
    }
}
