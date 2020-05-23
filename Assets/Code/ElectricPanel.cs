using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPanel : MonoBehaviour
{
    public void TurnPanelOnFor(float segs)
    {
        this.gameObject.SetActive(true);
        StartCoroutine(DeactivatePanelAfterTime(segs));
    }

    IEnumerator DeactivatePanelAfterTime(float segs)
    {
        yield return new WaitForSeconds(segs);
        this.gameObject.SetActive(false);
    }
}
