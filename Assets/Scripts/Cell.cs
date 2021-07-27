using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cell : MonoBehaviour
{ 
    [SerializeField]
    private PickableObject _containedObject;

    [SerializeField]
    private CellContentDisplay _cellContent;

    public void Setup()
    {
        _cellContent.ChangeSprite(_containedObject.Sprite);
    }

    public void SetContainedObject(PickableObject pickableObject)
    {
        _containedObject = pickableObject;
    }
}
