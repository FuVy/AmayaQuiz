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
    private int _maximumObjectsAmount;

    [SerializeField]
    private PickableBundle[] _objectsBundle;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private Transform _generatedCells;
    private void Start()
    {
        StartCoroutine(Generate());
    }

    public IEnumerator Generate()
    {
        int selectedBundleId = Random.Range(0, _objectsBundle.Length); //

        PickableBundle selectedBundle = _objectsBundle[selectedBundleId]; //

        int objectsInBundle = selectedBundle.PickableObjects.Length; 

        int rowsAmount = Mathf.CeilToInt((float)_maximumObjectsAmount / (float)_maximumColumnsAmount);

        Vector2 currentPosition = new Vector2(0, 0);
        Vector2 finalPosition = new Vector2();

        finalPosition.x = _padding * (_maximumColumnsAmount - 1);
        finalPosition.y = _padding * (-rowsAmount + 1);
        _generatedCells.position -= (Vector3)finalPosition / 2;
        int currentColumn = 0;

        for (int i = 0; i < _maximumObjectsAmount; i++)
        {
            currentColumn++;
            var generatedObject = Instantiate(_cellPrefab, (Vector3)currentPosition + _generatedCells.position, Quaternion.identity);
            generatedObject.transform.parent = _generatedCells;
            currentPosition.x += _padding;
            var cell = generatedObject.GetComponent<CellBehaviour>();
            cell.Initialize(selectedBundle.PickableObjects[Random.Range(0, objectsInBundle)]);

            if (currentColumn / _maximumColumnsAmount == 1)
            {
                currentPosition.x = 0;
                currentPosition.y -= _padding;
                currentColumn = 0;
            }
            yield return new WaitForSeconds(0.2f);
        }
        
    }

    IEnumerator WaitBeforeGenerate()
    {
        yield return new WaitForSeconds(1f);
        yield return null;
    }
}
