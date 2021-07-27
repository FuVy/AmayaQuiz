using System;
using UnityEngine;

[Serializable]
public class PickableObject
{
    [SerializeField]
    private string _identifier;
    
    [SerializeField]
    private Sprite _sprite;

    public string Identifier => _identifier;

    public Sprite Sprite => _sprite;
}
