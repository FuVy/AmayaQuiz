using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPickableObject", menuName = "PickableBundle")]
public class PickableBundle : ScriptableObject
{
    [SerializeField]
    private PickableObject[] _pickableObjects;

    public PickableObject[] PickableObjects => _pickableObjects;

    public int Quantity => _pickableObjects.Length;

    public void AddObject(PickableObject objectToAdd)
    {
        List<PickableObject> objects = new List<PickableObject>(_pickableObjects);
        objects.Add(objectToAdd);
        _pickableObjects = objects.ToArray();
    }

    public void Clear()
    {
        _pickableObjects = new PickableObject[0];
    }
}
