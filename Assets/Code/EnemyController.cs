using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform MoveTo;
    public float speed;
    public Action<GameObject> Die;

    private void Start()
    {
        MoveTo = GameObject.FindGameObjectWithTag("Base").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, MoveTo.position, Time.deltaTime * speed);
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Base") || collision.CompareTag("ElectricPanel"))
        {
            if (Die != null)
            {
                Die(this.gameObject);
            }
            StartCoroutine(DestroyAfterSeconds(0.1f));
        }
    }

    IEnumerator DestroyAfterSeconds(float sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(this.gameObject);
    }


}
