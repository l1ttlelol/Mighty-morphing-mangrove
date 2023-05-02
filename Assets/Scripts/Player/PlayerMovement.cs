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
    public int PlayerDirection;

    //References
    public Transform PlayerTransform;
    public Rigidbody2D RigidBody;
    public BoxCollider2D GroundCollider;
    public Transform Sprite;
    public GameObject Self;
    public Transform AttackRotationCounterweight;
    public AudioHandler AudioHandler;

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
        PlayerDirection = -1;
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
        PlayerDirection = 1;
    }

    //HANDLES THE PLAYERS JUMP
    public void Player_Jump()
    {
        RigidBody.AddForce(transform.up * JumpHeight);
        JumpAmount -= 1;
        AudioHandler.JumpAudio();
    }

    //HANDLES LANDING
    void OnTriggerStay2D(Collider2D collision)
    {
        if(Self.tag == "ground collider" && collision.tag != "Wall" && collision.tag != "TriggerBox")
        {
            JumpAmount = MaxJumpAmount;
            IsGrounded = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Self.tag == "ground collider" && collision.tag != "Wall" && collision.tag != "TriggerBox")
        {
            AudioHandler.LandingAudio();
        }
    }

    //HANDLES LEAVING THE GROUND
    void OnTriggerExit2D(Collider2D collision)
    {
        if (Self.tag == "ground collider")
        {
            IsGrounded = false;
        }
    }
}
