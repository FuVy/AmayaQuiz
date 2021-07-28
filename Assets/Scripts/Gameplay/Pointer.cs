using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour
{
    [SerializeField]
    private RightAnswerEvent RightAnswer;

    Camera _camera;
    private void Start()
    {
        
    }
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                var cellBehaviour = hit.collider.GetComponent<CellBehaviour>();
                if (cellBehaviour.HandleInput())
                {
                    RightAnswer.Invoke(cellBehaviour._cell.ContainedObject);
                }
            }
        }
    }
}

[System.Serializable]
public class RightAnswerEvent : UnityEvent<PickableObject>
{

}

