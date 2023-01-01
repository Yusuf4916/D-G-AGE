using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class enemyManager : MonoBehaviour
{

    public TextMeshPro enemyCountText;
    public GameObject enemy;

    void Start()
    {
        addEnemy(Random.Range(30, 60));
    }

    public void addEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity, transform);

        }
        for (int i = 2; i < count+1; i++)
        {
            float x = .5f * Mathf.Sqrt(i) * Mathf.Cos(i * 1 );
            float z = .5f * Mathf.Sqrt(i) * Mathf.Sin(i * 1);

            Vector3 newPos = new Vector3(x, 0, z);
            transform.GetChild(i).DOLocalMove(newPos, 1).SetEase(Ease.OutBack);
        }
        enemyCountText.text = transform.childCount.ToString();

    }

}
