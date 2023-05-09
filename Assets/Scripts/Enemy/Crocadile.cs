using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crocadile : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public LinearTriggerHandler TriggerHandler;
    public Transform SelfTransform;
    public Transform TriggerBoxTransform;
    public Transform DamageBoxTransform;
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
        DamageBoxTransform.position = SelfTransform.position;

        JumpTimer -= Time.deltaTime;

        if (TriggerHandler.IsTriggered == true)
        {
           
            if (JumpTimer <= 0)
            {
                JumpTimer = 3f;
                EnemyRigidBody.bodyType = RigidbodyType2D.Dynamic;
                EnemyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                EnemyRigidBody.AddForce(transform.up * 600);
                AudioHandler.CrocadileAudio();
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
            Health -= 1;
            AudioHandler.HitAudio();
        }
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
            Health -= 2;
            AudioHandler.HitAudio();
        }
        //HANDLES LANDING
        if (collision.gameObject.tag == "Water")
        {
            EnemyRigidBody.bodyType = RigidbodyType2D.Static;
            AudioHandler.SplashAudio();
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
