using UnityEngine;

public class CellContentDisplay : MonoBehaviour
{
    [SerializeField]
    private PickableObject _pickableObject;

    public void ChangeSprite(Sprite _sprite)
    {
        GetComponent<SpriteRenderer>().sprite = _sprite;
    }
}
