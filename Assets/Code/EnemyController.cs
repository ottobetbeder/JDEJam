using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Transform MoveTo;
    public float speed;

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
            Destroy(this.gameObject);
        }
    }
}
