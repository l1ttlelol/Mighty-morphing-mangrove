using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    //References

    public BoxCollider2D Hitbox;
    public TriggerHandler TriggerHandler;
    public Transform PlayerTransform;
    public Transform SelfTransform;
    public Transform TriggerBoxTransform;
    public Rigidbody2D EnemyRigidBody;

    //Variables
    public bool IsDirectionRight;
    public float Direction;
    public float Velocity;
    public bool IsColliding;

    // Update is called once per frame
    void Update()
    {
        TriggerBoxTransform.position = SelfTransform.position;

        if(IsDirectionRight == true)
        {
            SelfTransform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            SelfTransform.eulerAngles = new Vector3(0, 180, 0);
        }

        Direction = PlayerTransform.position.x - SelfTransform.position.x;

        if(TriggerHandler.IsTriggered == true)
        {
            if (Direction > 0.2f && IsColliding == false) 
            { 
                IsDirectionRight = true;
                SelfTransform.Translate(Vector3.right * Velocity * Time.deltaTime);
            }
            else if (Direction < -0.2f && IsColliding == false) 
            { 
                IsDirectionRight = false;
                SelfTransform.Translate(Vector3.right * Velocity * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsColliding = true;
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
