using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public TriggerHandler TriggerHandler;
    public Transform PlayerTransform;
    public Transform SelfTransform;
    public Transform TriggerBoxTransform;
    public Rigidbody2D EnemyRigidBody;
    public GameObject Self;
    public AudioHandler AudioHandler;

    //Variables
    public bool IsDirectionRight;
    public float Direction;
    public float Velocity;
    public bool IsColliding;
    public float JumpTimer;
    public int Health;
    public int MaxHealth;

    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerBoxTransform.position = SelfTransform.position;

        JumpTimer -= Time.deltaTime;

        if (IsDirectionRight == true)
        {
            SelfTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            SelfTransform.eulerAngles = new Vector3(0, 180, 0);
        }

        Direction = PlayerTransform.position.x - SelfTransform.position.x;

        if (TriggerHandler.IsTriggered == true)
        {
            if (Direction > 0.2f && IsColliding == false)
            {
                IsDirectionRight = true;
                if(JumpTimer <= 0)
                {
                    JumpTimer = 3.5f;
                    AudioHandler.FrogAudio();
                    EnemyRigidBody.AddForce(transform.up * 300);
                    EnemyRigidBody.AddForce(transform.right * 200);
                }
            }
            else if (Direction < -0.2f && IsColliding == false)
            {
                IsDirectionRight = false;
                if (JumpTimer <= 0)
                {
                    JumpTimer = 3.5f;
                    AudioHandler.FrogAudio();
                    EnemyRigidBody.AddForce(transform.up * 300);
                    EnemyRigidBody.AddForce(transform.right * 200);
                }
            }
        }

        if (Health <= 0)
        {
            Self.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = true;
        }
        if (collision.gameObject.tag == "Player Attack")
        {
            AudioHandler.HitAudio();
            Health -= 1;
        }
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
            AudioHandler.HitAudio();
            Health -= 2;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = false;
        }
    }
}
