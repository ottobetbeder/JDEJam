using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricNode : MonoBehaviour
{
    public int nodeId;
    public Action<ElectricNode> NodeTouched;

    [SerializeField]
    private GameObject activeNode;


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
        activeNode.SetActive(turnOnAndOff > 0);
    }
}
