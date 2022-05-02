using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class AspectCircleIcon : MonoBehaviour
{
    [SerializeField] private AspectCircleIconData data;
    [SerializeField] private Image[] circleImages = new Image[4];

    private List<AspectType> _usedAspects;

    public void UpdateCircleIcon(List<AspectType> usedAspects)
    {
        _usedAspects = usedAspects;

        for (var i = 0; i < circleImages.Length; i++)
        {
            circleImages[i].sprite = data.AspectSpritesInactive[i];
        }

        foreach (var aspectType in _usedAspects)
        {
            var i = (int)(aspectType - 1);
            circleImages[i].sprite = data.AspectSpritesActive[i];
        }
    }
}
