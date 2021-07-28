using System;
using UnityEngine;

[Serializable]
public class PickableObject
{
    [SerializeField]
    private string _identifier;

    [SerializeField]
    private string _ingameName;

    [SerializeField]
    private Sprite _sprite;

    public string Identifier => _identifier;

    public string IngameName => _ingameName;

    public Sprite Sprite => _sprite;
}
