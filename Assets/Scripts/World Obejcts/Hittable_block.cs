using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hittable_block : MonoBehaviour
{
    public Rigidbody2D BlockPhysics;
    public bool IsGrounded;
    public Transform Collider;
    public Transform Detector;
    public AudioHandler AudioHandler;

    void Update()
    {
        Detector.position = Collider.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //HANDLES LANDING
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "UnrecoverableDamage")
        {
            IsGrounded = true;
            BlockPhysics.bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.tag == "UnrecoverableDamage") { AudioHandler.SplashAudio(); }
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
