using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityGrab : MonoBehaviour
{
    public GameObject[] WhipSegments;
    public float WhipTimer;
    public int ActiveSegmentCount;

    public Sprite HolsteredSprite;
    public Sprite ActiveSprite;
    public Sprite SegmentEndSprite;
    public Sprite SegmentMiddleSprite;
    public SpriteRenderer WhipBaseSpriteRenderer;
    public SpriteRenderer WhipSegmentSpriteRenderer;

    void Update()
    {
        WhipTimer -= Time.deltaTime;

        if (WhipTimer > 0.24f)
        {
            ActiveSegmentCount = 1;
            WhipBaseSpriteRenderer.sprite = ActiveSprite;
        }
        else if (WhipTimer > 0.18f)
        {
            ActiveSegmentCount = 2;
            WhipBaseSpriteRenderer.sprite = ActiveSprite;
        }
        else if (WhipTimer > 0.12f)
        {
            ActiveSegmentCount = 3;
            WhipBaseSpriteRenderer.sprite = ActiveSprite;
        }
        else if (WhipTimer > 0.6f)
        {
            ActiveSegmentCount = 4;
            WhipBaseSpriteRenderer.sprite = ActiveSprite;
        }
        else if (WhipTimer > 0)
        {
            ActiveSegmentCount = 5;
            WhipBaseSpriteRenderer.sprite = ActiveSprite;
        }
        else
        {
            ActiveSegmentCount = 0;
            WhipBaseSpriteRenderer.sprite = HolsteredSprite;
        }



        for (int i = 0; i < ActiveSegmentCount; i++)
        {
            if (i < ActiveSegmentCount)
            {
                WhipSegments[i].SetActive(true);

                WhipSegmentSpriteRenderer = WhipSegments[i].GetComponent<SpriteRenderer>();

                if (i == ActiveSegmentCount - 1)
                {
                    WhipSegmentSpriteRenderer.sprite = SegmentEndSprite;
                }
                else
                {
                    WhipSegmentSpriteRenderer.sprite = SegmentMiddleSprite;
                }
            }
            else
            {
                WhipSegments[i].SetActive(false);
            }
        }
    }

    public void PlayerAbility_Grab()
    {
        WhipTimer = 0.3f;
        for (int i = 0; i < 5; i++)
        {
            WhipSegments[i].SetActive(false);
        }
    }
}
