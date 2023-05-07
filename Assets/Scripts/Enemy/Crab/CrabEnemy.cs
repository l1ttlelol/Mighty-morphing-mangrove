using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabEnemy : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public TriggerHandler TriggerHandler;
    public Transform PlayerTransform;
    public Transform SelfTransform;
    public Transform WallBoxTransform;
    public Transform FloorBoxTransform;
    public Rigidbody2D EnemyRigidBody;
    public GameObject Self;

    //Variables
    public bool IsDirectionRight;
    public float Velocity;
    public bool IsColliding;
    public int Health;
    public int MaxHealth;

    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        FloorBoxTransform.position = SelfTransform.position;
        WallBoxTransform.position = SelfTransform.position;

        if (IsDirectionRight == true)
        {
            SelfTransform.eulerAngles = new Vector3(0, 0, 0);
            WallBoxTransform.eulerAngles = new Vector3(0, 0, 0);
            FloorBoxTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            SelfTransform.eulerAngles = new Vector3(0, 180, 0);
            WallBoxTransform.eulerAngles = new Vector3(0, 180, 0);
            FloorBoxTransform.eulerAngles = new Vector3(0, 180, 0);
        }

        SelfTransform.Translate(Vector3.right * Velocity * Time.deltaTime);

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
        }
        if (collision.gameObject.tag == "Player HeavyAttack")
        {
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
