using UnityEngine;

public class CellContentDisplay : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _cellSpriteRenderer;

    public void ChangeSprite(Sprite _sprite)
    {
        _cellSpriteRenderer.sprite = _sprite;
    }
}
