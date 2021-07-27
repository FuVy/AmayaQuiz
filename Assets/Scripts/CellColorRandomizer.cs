using UnityEngine;

public class CellColorRandomizer : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float _saturation = 0.4f, _brightness = 0.9f;

    [SerializeField]
    private SpriteRenderer _backgroundSpriteRenderer;
    private void Awake()
    {
        float _hue = Random.Range(0f, 1f);
        _backgroundSpriteRenderer.color = Color.HSVToRGB(_hue, _saturation, _brightness);
    }
}
