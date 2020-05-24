using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d; 
    Vector2 movement;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private CoolDownHability dashCooldown;
    private float moveHorizontal;
    private float moveVertical;
    [SerializeField] private GameObject DashEffect;
    [SerializeField] private float cooldownTime;
    private bool isDashing;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        dashCooldown = new CoolDownHability(cooldownTime);
    }

    void FixedUpdate()
    {

        if (!isDashing)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            if (movement != Vector2.zero)
            {
                rb2d.MovePosition(rb2d.position + movement * speed * Time.deltaTime);

                //Dash
                if (Input.GetKeyDown(KeyCode.Space) && dashCooldown.IsCoolDownCompleted)
                {
                    isDashing = true;
                    //Instantiate(DashEffect, transform.position, Quaternion.identity);
                    dashCooldown.SetCooldown();
                }
            }
        }
        else
        {
            if (dashTime < 0)
            {
                //the dash has just finished
                isDashing = false;
                dashTime = startDashTime;
                rb2d.velocity = Vector3.zero;
            }
            else
            {
                //is dashing
                dashTime -= Time.deltaTime;

                Vector2 movement = new Vector2(System.Math.Sign(moveHorizontal) , System.Math.Sign(moveVertical) );
                movement.Normalize();
                rb2d.MovePosition(rb2d.position + movement * dashSpeed * Time.deltaTime);
            }
        }
    }
}
