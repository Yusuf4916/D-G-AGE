using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barrier : MonoBehaviour
{
    public TextMeshPro gate;
    public int randomGate,randomMinPlus,randomMaxPlus,randomMinMultiple,randomMaxMultiple,chose;

    void Start()
    {
        chose = Random.Range(1, 3);
        if (chose==1)
        {
            randomGate = Random.Range(randomMinPlus, randomMaxPlus);
            gate.text = "+" + randomGate.ToString();
        }
        else if(chose==2)
        {
            randomGate = Random.Range(randomMinMultiple,randomMaxMultiple);
            gate.text = "x" + randomGate.ToString();
        }
        
    }

}
