using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CellBehaviour : MonoBehaviour, IInitializable
{
    public Cell _cell { get; private set; }

    [SerializeField, Range(0f, 1.3f)]
    private float _disabledColliderDuration = 0.7f;

    [SerializeField]
    private CellContentDisplay _contentDisplay;

    [SerializeField]
    private ParticlesHandler _particlesHandler;

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
        if (PlayerPrefs.GetString("alreadyInitialized") != "true")
        {
            transform.localScale = Vector3.zero;
            transform.BounceIn();
            //PlayerPrefs.SetString("alreadyInitialized", "true");
        }
        else
        {
            _disabledColliderDuration = 0f;
        }
        StartCoroutine(DisableCollider(_disabledColliderDuration));
        
        
    }
    private IEnumerator DisableCollider(float duration)
    {
        _collider.enabled = false;
        yield return new WaitForSeconds(duration);
        _collider.enabled = true;
    }

    public bool IsAnswer()
    {
        bool correctAnswer = _cell.Identifier == PlayerPrefs.GetString("answer");

        if (correctAnswer)
        {
            _collider.enabled = false;
            _contentDisplay.transform.Bounce(1.3f, 0.7f, Ease.InOutBounce);
            _particlesHandler.StartEmission();
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


