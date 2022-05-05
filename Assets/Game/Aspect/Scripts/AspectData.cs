using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "AspectData", menuName = "Aspect/AspectData")]
public class AspectData : ScriptableObject
{
    public List<AspectHolder> AspectIcons = new List<AspectHolder>();

    public Sprite GetAspectIcon(AspectType aspect)
    {
        foreach (var aspectIcon in AspectIcons)
        {
            if (aspectIcon.Matches(aspect))
            {
                return aspectIcon.Sprite;
            }
        }

        return null;
    }
}
