using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class TweenExtension
{
    public static void BounceIn(this Transform transform)
    {
        transform.Bounce(1f, 1.3f, Ease.InBounce);
    }

    public static void BounceOut(this Transform transform)
    {
        transform.Bounce(0f, 1f, Ease.Linear);
    }

    public static void Bounce(this Transform transform, float value, float duration, Ease ease)
    {
        transform.DORewind();
        transform.DOScale(value, duration).SetEase(ease);
    }

    public static void Shake(this Transform transform)
    {
        transform.DORewind();
        transform.DOShakeScale(1f, 0.3f, 3)
            .SetEase(Ease.InBounce);
        transform.DOShakePosition(1f, 0.4f, 6)
            .SetEase(Ease.InBounce);
    }
}
