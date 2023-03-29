using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float Velocity;
    public float JumpHeight;
    public int JumpAmount;
    public int MaxJumpAmount;

    //References
    public Transform PlayerTransform;
    public Rigidbody2D RigidBody;
    public BoxCollider2D Collider;

    public void Player_MoveLeft()
    {
        PlayerTransform.Translate(Vector3.left * Velocity * Time.deltaTime);
    }
    
    public void Player_MoveRight()
    {
        PlayerTransform.Translate(Vector3.right * Velocity * Time.deltaTime);
    }

    public void Player_Jump()
    {
        RigidBody.AddForce(transform.up * JumpHeight);
        JumpAmount -= 1;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            JumpAmount = MaxJumpAmount;
        }
    }
}
