using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable_block : MonoBehaviour
{
    public Rigidbody2D BlockPhysics;
    public GameObject PlayerAttack;
    public bool IsGrounded;

    public PlayerMovement PlayerMovement;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == PlayerAttack)
        {
            BlockPhysics.bodyType = RigidbodyType2D.Dynamic;
            BlockPhysics.constraints = RigidbodyConstraints2D.FreezeRotation;
            BlockPhysics.AddForce(transform.up * 150);
            BlockPhysics.AddForce(new Vector2(PlayerMovement.PlayerDirection * 200, 0));
        }

        //HANDLES LANDING
        if (collision.gameObject.tag == "Floor")
        {
            IsGrounded = true;
            BlockPhysics.bodyType = RigidbodyType2D.Static;
        }
    }

    //HANDLES LEAVING THE GROUND
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            IsGrounded = false;
        }
    }
}
