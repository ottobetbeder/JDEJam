using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricPanel : MonoBehaviour
{
    public AudioSource electricity;

    public void TurnPanelOnFor(float segs)
    {
        this.gameObject.SetActive(true);
        electricity.Play();
        StartCoroutine(DeactivatePanelAfterTime(segs));
    }

    IEnumerator DeactivatePanelAfterTime(float segs)
    {
        yield return new WaitForSeconds(segs);
        electricity.Stop();
        this.gameObject.SetActive(false);
    }
}
