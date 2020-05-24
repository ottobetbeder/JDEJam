using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public int boosterId;
    public Action<Booster> BoosterTouched;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (BoosterTouched != null)
            {
                BoosterTouched(this);
            }
            Destroy(this.gameObject);
        }
    }
    //destruirlo por tiempo tmb
}
