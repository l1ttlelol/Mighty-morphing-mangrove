using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    //Contains data that is character specific
    public Sprite IdleSprite;
    public Sprite Run1;
    public Sprite Run2;
    public Sprite JumpSprite;
    public int MaxJumps;
}
