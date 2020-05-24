using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    public AudioSource audioHurt;

    public Action BaseHurt;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            audioHurt.Play();
            if (BaseHurt != null)
            {
                BaseHurt();
            }
        }
    }
}
