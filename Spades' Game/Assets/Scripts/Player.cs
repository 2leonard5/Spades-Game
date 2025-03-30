using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class player : MonoBehaviour
{
    public Rigidbody2D body;
    private BoxCollider2D boxCollider;
    public LayerMask groundLayer;
    public LayerMask wallLayer;
    public float jumpStartTime;
    public float jumpForce;
    public float runspeed;
    private float jumpTime;
    private bool isJumping = false;
    private GameObject Player;
    private GameObject Head;
    public bool IsGrappling;
    private float walljumpcooldown;
    public float acceleration;
    public float decceleration;
    public float velPower;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (walljumpcooldown > 0.5)
        {
            Jump();
            Run();
        }
        else walljumpcooldown += Time.deltaTime;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isGrounded() == true)
            {
                isJumping = true;
                jumpTime = jumpStartTime;
                body.linearVelocity = new Vector2(body.linearVelocityX, body.linearVelocityY * jumpForce);

            }
            else if (onWall())
            {
                walljumpcooldown = 0;
                body.linearVelocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 15, 30);

            }
        }
        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTime > 0)
            {
                body.linearVelocity = new Vector2(body.linearVelocityX, jumpForce);
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;
        }
        if (!(isJumping || isGrounded()))
            body.gravityScale = 7;
        else
            body.gravityScale = 4;
    }

    private void Run()
    {
        float xin = Input.GetAxis("Horizontal");
        if (xin != 0)
        {
            if (IsGrappling == true)
                body.AddRelativeForceX(xin * runspeed);
            else
                if (!onWall())
            {
                float targetSpeed = xin * runspeed;
                float speedDif = targetSpeed - body.linearVelocity.x;
                float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;
                float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);

                body.AddForce(movement * Vector2.right);
            }
            if (xin > 0.01)
                transform.localScale = new Vector3(1, 1, 1);
            else if (xin < -0.01)
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
}

