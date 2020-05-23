using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricNode : MonoBehaviour
{
    [SerializeField]
    private int nodeId;
    public Action<int> NodeTouched;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && NodeTouched != null)
        {
            NodeTouched(nodeId);
        }
    }
}
