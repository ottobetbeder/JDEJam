using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricNode : MonoBehaviour
{
    public int nodeId;
    public Action<ElectricNode> NodeTouched;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && NodeTouched != null)
        {
            ChangeNodeVisual();
            NodeTouched(this);
        }
    }

    int turnOnAndOff = -1;
    public void ChangeNodeVisual()
    {
        turnOnAndOff *= -1;

        if (turnOnAndOff > 0)
        {
            //turn node on colour etc
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            //turn node on colour etc
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
