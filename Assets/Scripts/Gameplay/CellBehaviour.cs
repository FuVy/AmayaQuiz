using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellBehaviour : MonoBehaviour, IInitializable
{
    public Cell _cell { get; private set; }

    [SerializeField]
    private CellContentDisplay _contentDisplay;

    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    public void Initialize(PickableObject containedObject)
    {
        _cell = new Cell();
        _cell.SetContainedObject(containedObject);
        _contentDisplay.ChangeSprite(_cell.Sprite);

        //StartCoroutine(DisableCollider(1.3f));
        transform.localScale = Vector3.zero;
        transform.BounceIn();
    }
    private IEnumerator DisableCollider(float duration)
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(duration);
        _collider.enabled = true;
    }

    public bool HandleInput()
    {
        bool correctAnswer = _cell.Identifier == PlayerPrefs.GetString("answer");

        if (correctAnswer)
        {
            _collider.enabled = false;
            _contentDisplay.transform.Bounce(1.3f, 0.7f, Ease.InOutBounce);
            return true;
        }
        else
        {
            _contentDisplay.transform.Shake();
            return false;
        }
    }
}

public class Cell
{
    public PickableObject ContainedObject { get; private set; }

    public string Identifier => ContainedObject.Identifier;

    public Sprite Sprite => ContainedObject.Sprite;

    public void SetContainedObject(PickableObject containedObject)
    {
        ContainedObject = containedObject;
    }
}


