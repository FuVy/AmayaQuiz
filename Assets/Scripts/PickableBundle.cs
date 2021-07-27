using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPickableObject", menuName = "PickableBundle")]
public class PickableBundle : ScriptableObject
{
    [SerializeField]
    private PickableObject[] _pickableObjects;

    public PickableObject[] PickableObjects => _pickableObjects;
}
