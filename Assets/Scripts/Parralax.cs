using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private float length, startpos;
    private float lengthY, startposY;
    public GameObject Camera;
    public float ParallaxEffect;
    public float ParallaxEffectY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        startposY = transform.position.y;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (Camera.transform.position.x * (1 - ParallaxEffect));
        float dist = (Camera.transform.position.x * ParallaxEffect);
        float distY = (Camera.transform.position.y * ParallaxEffectY);

        transform.position = new Vector3(startpos + dist, startposY + distY, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
