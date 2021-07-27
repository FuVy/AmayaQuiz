using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellGenerator : MonoBehaviour
{
    [SerializeField]
    private float _padding;

    [SerializeField]
    private int _maximumColumnsAmount;

    [SerializeField]
    private PickableBundle[] _objectsBundle;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private Transform _generatedCells;
    private void Start()
    {
        Generate();
    }
    /*
    public void Generate()
    {
        int selectedBundleId = Random.Range(0, _objectsBundle.Length);

        //Vector2 currentPosition = new Vector2(Screen.width/2, Screen.height/2);

        PickableBundle selectedBundle = _objectsBundle[selectedBundleId];

        int objectsAmount = selectedBundle.PickableObjects.Length;

        int rawsAmount = (int)Mathf.Ceil(objectsAmount / _maximumColumnsAmount);

        Vector2 shift = new Vector2(0, 0);

        if (rawsAmount / 2 == 1)
        {
            shift += new Vector2(0, +_padding / 2f);
        }
        if (_maximumColumnsAmount / 2 == 1)
        {
            shift += new Vector2(+_padding / 2f, 0);
        }
        Debug.Log(shift);
        Vector2 currentPosition = new Vector2(-_maximumColumnsAmount * _padding / 2f, rawsAmount * _padding / 2f) + shift;
        float initialX = currentPosition.x;
        int currentColumn = 0;
        for (int i = 0; i < objectsAmount; i++)
        {
            currentColumn++;
            Instantiate(_cellPrefab, currentPosition, Quaternion.identity);
            currentPosition.x += _padding;
            if (currentColumn / _maximumColumnsAmount == 1)
            {
                currentPosition.x = initialX;
                currentPosition.y -= _padding;
                currentColumn = 0;
            }
        }
    }
    */

    public void Generate()
    {
        int selectedBundleId = Random.Range(0, _objectsBundle.Length);

        //Vector2 currentPosition = new Vector2(Screen.width/2, Screen.height/2);

        PickableBundle selectedBundle = _objectsBundle[selectedBundleId];

        int objectsAmount = selectedBundle.PickableObjects.Length;

        int rawsAmount = (int)Mathf.Ceil(objectsAmount / _maximumColumnsAmount);

        Vector2 currentPosition = new Vector2(0, 0);
        Vector2 initialPosition = new Vector2(currentPosition.x, 0);
        Vector2 finalPosition = new Vector2();
        int currentColumn = 0;
        for (int i = 0; i < objectsAmount; i++)
        {
            currentColumn++;

            var generatedObject = Instantiate(_cellPrefab, currentPosition, Quaternion.identity);
            generatedObject.transform.parent = _generatedCells;
            currentPosition.x += _padding;
            var cell = generatedObject.GetComponent<Cell>();
            cell.SetContainedObject(selectedBundle.PickableObjects[i]);
            cell.Setup();

            if (currentColumn / _maximumColumnsAmount == 1)
            {
                finalPosition.x = currentPosition.x;
                currentPosition.x = initialPosition.x;
                currentPosition.y -= _padding;
                currentColumn = 0;
            }
            finalPosition.y = currentPosition.y;            
        }

        Vector2 center = (finalPosition - initialPosition) / 2;
        //
    }

    /*
    void Start()
    {
        for (int i = 0; i < _objects.GetLength(0); i++)
        {
            for (int j = 0; j < _objects.GetLength(1); j++)
            {
                Debug.Log(i + " " + j);
            }
        }
    }
    */
}
