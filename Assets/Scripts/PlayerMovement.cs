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
    public int Direction = 0;
    public bool IsGrounded = false;
    public float Friction = 0.95f;

    //References
    public Transform PlayerTransform;
    public Rigidbody2D RigidBody;
    public BoxCollider2D GroundCollider;
    public Transform Sprite;
    public GameObject Self;
    public Transform AttackRotationCounterweight;

    //HANDLES THE PLAYERS LEFT MOVEMENT
    public void Player_MoveLeft()
    {
        if (IsGrounded == true)
        {
            PlayerTransform.Translate(Vector3.left * Velocity * Time.deltaTime * Friction);
        }
        else
        {
            PlayerTransform.Translate(Vector3.left * Velocity * Time.deltaTime);
        }
        Sprite.eulerAngles = new Vector3(0, 180, 0);
        AttackRotationCounterweight.eulerAngles = new Vector3(0, 180, 0);
    }
    
    //HANDLES THE PLAYERS RIGHT MOVEMENT
    public void Player_MoveRight()
    {
        if (IsGrounded == true)
        {
            PlayerTransform.Translate(Vector3.right * Velocity * Time.deltaTime * Friction);
        }
        else
        {
            PlayerTransform.Translate(Vector3.right * Velocity * Time.deltaTime);
        }
        Sprite.eulerAngles = new Vector3(0, 0, 0);
        AttackRotationCounterweight.eulerAngles = new Vector3(0, 0, 0);
    }

    //HANDLES THE PLAYERS JUMP
    public void Player_Jump()
    {
        RigidBody.AddForce(transform.up * JumpHeight);
        JumpAmount -= 1;
    }

    //HANDLES LANDING
    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor" && Self.tag == "ground collider")
        {
            JumpAmount = MaxJumpAmount;
            IsGrounded = true;
        }
    }
    
    //HANDLES LEAVING THE GROUND
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" && Self.tag == "ground collider")
        {
            IsGrounded = false;
        }
    }
}
