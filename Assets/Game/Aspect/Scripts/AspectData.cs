using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AspectData : ScriptableObject
{
    public Dictionary<AspectType, Sprite> AspectIcons;

    public Sprite GetAspectIcon(AspectType aspect)
    {
        if (AspectIcons.TryGetValue(aspect, out Sprite icon))
        {
            return icon;
        }

        return null;
    }
}
