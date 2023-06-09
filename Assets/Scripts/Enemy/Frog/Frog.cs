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

    public Sprite Sprite1;
    public Sprite Sprite2;
    public SpriteRenderer SpriteRenderer;

    //Variables
    public bool IsDirectionRight;
    public float Direction;
    public float Velocity;
    public bool IsColliding;
    public float JumpTimer;
    public int Health;
    public int MaxHealth;
    public float ImmunityTimer;

    void Start()
    {
        Health = MaxHealth;
        SpriteRenderer.sprite = Sprite2;
    }

    // Update is called once per frame
    void Update()
    {
        TriggerBoxTransform.position = SelfTransform.position;

        JumpTimer -= Time.deltaTime;

        ImmunityTimer -= Time.deltaTime;

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
                    SpriteRenderer.sprite = Sprite1;
                }
                /*else
                {
                    SpriteRenderer.sprite = Sprite2;
                }*/
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
                    SpriteRenderer.sprite = Sprite1;
                }
                /*else
                {
                    SpriteRenderer.sprite = Sprite2;
                }*/
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
        if (collision.gameObject.tag == "Player Attack" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 1;
            ImmunityTimer = 0.4f;
        }
        if (collision.gameObject.tag == "Player HeavyAttack" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 2;
            ImmunityTimer = 0.4f;
        }
        if (collision.gameObject.tag == "Whip" && ImmunityTimer <= 0)
        {
            AudioHandler.HitAudio();
            Health -= 1;
            ImmunityTimer = 0.4f;
        }

        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Player Attack" && collision.gameObject.tag != "Player HeavyAttack" && collision.gameObject.tag != "Whip")
        {
            SpriteRenderer.sprite = Sprite2;
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
