using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHegiht : MonoBehaviour
{
    public float StartHeight;
    public float FirstHeight;
    public float SecondHeight;
    public float ThirdHeight;
    public float FourthHeight;
    public int CurrentHeight;

    public Transform Self;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHeight = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHeight == 0)
        {
            Self.position = new Vector2(52.06f, StartHeight);
        }
        if (CurrentHeight == 1)
        {
            Self.position = new Vector2(52.06f, FirstHeight);
        }
        if (CurrentHeight == 2)
        {
            Self.position = new Vector2(52.06f, SecondHeight);
        }
        if (CurrentHeight == 3)
        {
            Self.position = new Vector2(52.06f, ThirdHeight);
        }
        if (CurrentHeight == 4)
        {
            Self.position = new Vector2(52.06f, FourthHeight);
        }
    }
}
