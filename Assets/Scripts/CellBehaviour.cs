using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellBehaviour : MonoBehaviour, IInitializable
{
    [SerializeField]
    private PickableObject _containedObject;

    [SerializeField]
    private CellContentDisplay _contentDisplay;
    private void Start()
    {
        transform.BounceIn();
    }
    public void Initialize(PickableObject containedObject)
    {
        _containedObject = containedObject;

        _contentDisplay.ChangeSprite(_containedObject.Sprite);
    }

    private void OnMouseDown()
    {
        TweenExtension.BounceOut(transform);
    }
}

