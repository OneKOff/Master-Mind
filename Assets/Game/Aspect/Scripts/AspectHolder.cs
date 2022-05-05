using UnityEngine;

[System.Serializable]
public class AspectHolder
{
    public AspectType AspectType;
    public Sprite Sprite;

    public bool Matches(AspectType type)
    {
        return AspectType == type;
    }
}