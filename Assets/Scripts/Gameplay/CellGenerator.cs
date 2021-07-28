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
    private GameObject _cellPrefab;

    [SerializeField]
    private Transform _generatedCells;
    public void GenerateCells(PickableObject[] selectedKit)
    {
        StartCoroutine(Generate(selectedKit));
    }
    private IEnumerator Generate(PickableObject[] selectedKit)
    { 
        int objectsInKit = selectedKit.Length;

        int rowsAmount = Mathf.CeilToInt((float)objectsInKit / (float)_maximumColumnsAmount);

        Vector2 currentPosition = new Vector2(0, 0);
        Vector2 finalPosition;

        finalPosition.x = _padding * (_maximumColumnsAmount - 1);
        finalPosition.y = _padding * (-rowsAmount + 1);
        _generatedCells.position -= (Vector3)finalPosition / 2;
        int currentColumn = 0;

        for (int i = 0; i < objectsInKit; i++)
        {
            currentColumn++;
            var generatedObject = Instantiate(_cellPrefab, (Vector3)currentPosition + _generatedCells.position, Quaternion.identity);
            generatedObject.transform.parent = _generatedCells;
            currentPosition.x += _padding;
            var cell = generatedObject.GetComponent<CellBehaviour>();
            cell.Initialize(selectedKit[i]);

            if (currentColumn / _maximumColumnsAmount == 1)
            {
                currentPosition.x = 0;
                currentPosition.y -= _padding;
                currentColumn = 0;
            }
            if (PlayerPrefs.GetString("alreadyInitialized") != "true")
            {
                yield return new WaitForSeconds(0.2f);
            }
        }
        if (PlayerPrefs.GetString("alreadyInitialized") != "true")
        {
            PlayerPrefs.SetString("alreadyInitialized", "true");
        }
    }
}
