using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class TweenExtension
{
    private static Transform _transform;
    public static void BounceIn(this Transform transform)
    {
        transform.DOScale(0, 0).OnComplete(() =>
        {
            transform.DOScale(1.05f, 0.3f).OnComplete(() =>
            {
                transform.DOScale(1f, 0.1f);
            });
        });
    }
    public static void BounceOut(this Transform transform)
    {
        transform.DOScale(0, 1f).onComplete();
    }
    public static void EaseInBounce(this Transform transform)
    {
        float[] keyframesValues = { .04f, .04f, .10f, .08f, .20f, .18f, .12f, .12f, .12f };
        float totalTime = 1.2f;
        int currentFrame = 0;
        transform.DOScale()
    }
}
