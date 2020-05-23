using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> electricPanels;

    [SerializeField]
    private List<GameObject> electricNodes;

    [SerializeField]
    private float panelCooldown;

    private List<int> nodesPressed;

    private void Start()
    {
        nodesPressed = new List<int>();
        foreach (GameObject item in electricNodes)
        {
            item.GetComponent<ElectricNode>().NodeTouched += OnNodeTouched;
        }
    }

    private void OnNodeTouched(int id)
    {
        if (nodesPressed.Count < 2)
        {
            if (nodesPressed.Contains(id))
            {
                nodesPressed.Remove(id);
            }
            else
            {
                nodesPressed.Add(id);
            }
        }
    }

    private void Update()
    {
        if (nodesPressed.Count >= 2)
        {
            TurnOnPanel(nodesPressed[0]*10+ nodesPressed[1]);
            nodesPressed.Clear();
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
