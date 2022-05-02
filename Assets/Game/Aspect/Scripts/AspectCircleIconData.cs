using UnityEngine;
using System.Collections;

public class AspectCircleIconData : ScriptableObject
{
    [SerializeField] private Sprite[] aspectSpritesActive = new Sprite[4];
    public Sprite[] AspectSpritesActive => aspectSpritesActive;
    [SerializeField] private Sprite[] aspectSpritesInactive = new Sprite[4];
    public Sprite[] AspectSpritesInactive => aspectSpritesInactive;
}
