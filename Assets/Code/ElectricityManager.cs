using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> electricPanels;

    [SerializeField]
    private List<ElectricNode> electricNodes;

    [SerializeField]
    private float panelCooldown;

    private List<int> nodesPressed;

    private void Start()
    {
        nodesPressed = new List<int>();
        foreach (ElectricNode item in electricNodes)
        {
            item.NodeTouched += OnNodeTouched;
        }
    }

    private void OnNodeTouched(ElectricNode node)
    {
        if (nodesPressed.Count < 2)
        {
            if (!nodesPressed.Contains(node.nodeId))
            {
                nodesPressed.Add(node.nodeId);
            }
        }
    }

    private void Update()
    {
        if (nodesPressed.Count >= 2)
        {
            int nodeAux = nodesPressed[1];
            TurnOnPanel(nodesPressed[0]*10+ nodesPressed[1]);
            TurnPanelVisualOff(nodesPressed[0]);

            nodesPressed.Remove(nodesPressed[0]);
        }
    }

    void TurnPanelVisualOff(int id)
    {
        foreach (ElectricNode item in electricNodes)
        {
            if (item.nodeId == id)
            {
                item.TurnOffNodeActiveImage();
                break;
            }
        }
    }


    private void TurnOnPanel(int panelIds)
    {
        switch (panelIds)
        {
            case 12:
            case 21:
                electricPanels[0].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 23:
            case 32:
                electricPanels[1].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 34:
            case 43:
                electricPanels[2].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 45:
            case 54:
                electricPanels[3].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 56:
            case 65:
                electricPanels[4].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 67:
            case 76:
                electricPanels[5].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 78:
            case 87:
                electricPanels[6].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;

            case 18:
            case 81:
                electricPanels[7].GetComponent<ElectricPanel>().TurnPanelOnFor(panelCooldown);
                break;
        }
    }
}
