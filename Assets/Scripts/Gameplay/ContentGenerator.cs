using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class ContentGenerator : MonoBehaviour
{
    [SerializeField]
    private List<PickableBundle> _bundles;
    
    [SerializeField]
    private PickableBundle _bannedBundle;

    [SerializeField]
    private int _minimumAmount = 3, _maximumAmount = 9, _increment = 3;

    [SerializeField]
    private UnityEvent<string> ContentGenerated;

    private PickableObject _correctObject;

    private PickableBundle _selectedBundle;

    private int _amountToGenerate;
    
    private void Start()
    {
        CalculateAmountToGenerate();

        CountAllObjects();
        FilterBundles();
        SelectBundle();

        if (_selectedBundle.PickableObjects.Length < _amountToGenerate)
        {
            _amountToGenerate = _selectedBundle.PickableObjects.Length;
        }

        var suitableBundle = SuitableObjects(_selectedBundle);
        if (suitableBundle.Length < 1)
        {
            Debug.LogError("error");
            Debug.Log(suitableBundle.Length);
            return;
        }
        var generatedKit = GenerateKit(suitableBundle);
        var correctIdentifier = SelectCorrectIdentifier(generatedKit);
        GetComponent<CellGenerator>().GenerateCells(generatedKit);
        PlayerPrefs.SetString("answer", correctIdentifier);



        ContentGenerated.Invoke("Find " + _correctObject.IngameName);
    }

    private void CalculateAmountToGenerate()
    {
        _amountToGenerate = PlayerPrefs.GetInt("amountToGenerate");
        if (_amountToGenerate == 0)
        {
            _amountToGenerate = _minimumAmount;
        }
        else
        {
            _amountToGenerate += _increment;
        }
        _amountToGenerate = Mathf.Clamp(_amountToGenerate, _minimumAmount, _maximumAmount);
        PlayerPrefs.SetInt("amountToGenerate", _amountToGenerate);
    }

    private void CountAllObjects()
    {
        int totalAmount = 0;

        foreach (PickableBundle bundle in _bundles)
        {
            totalAmount += bundle.Quantity;
        }

        if (PlayerPrefs.GetInt("totalAmount") < totalAmount)
        {
            PlayerPrefs.SetInt("totalAmount", totalAmount);
        }
    }

    private void FilterBundles()
    {
        for (int i = _bundles.Count - 1; i >= 0; i--)
        {
            if (SuitableObjects(_bundles[i]).Length < 1) //|| _bundles[i].PickableObjects.Length < )
            {
                _bundles.Remove(_bundles[i]);
            }
        }
    }
    
    private void SelectBundle()
    {
        _selectedBundle = _bundles[Random.Range(0, _bundles.Count)];
    }
    
    private string SelectCorrectIdentifier(PickableObject[] generatedKit)
    {
        int length = generatedKit.Length;
        string[] bannedIdentifiers = BannedIdentifiers();
        string selectedIdentifier;
        do
        {
            int i = Random.Range(0, length);
            selectedIdentifier = generatedKit[i].Identifier;
            _correctObject = generatedKit[i];
        }
        while (bannedIdentifiers.Contains(selectedIdentifier));
        
        return selectedIdentifier;
    }

    private PickableObject[] SuitableObjects(PickableBundle desiredBundle)
    {
        List<PickableObject> objects = new List<PickableObject>();
        string[] bannedIdentifiers = BannedIdentifiers();
        for (int i = 0; i < desiredBundle.PickableObjects.Length; i++)
        {
            if (!bannedIdentifiers.Contains(desiredBundle.PickableObjects[i].Identifier))
            {
                objects.Add(desiredBundle.PickableObjects[i]);
            }
        }
        return objects.ToArray();
    }

    private string[] BannedIdentifiers()
    {
        string[] bannedIdentifiers = new string[_bannedBundle.PickableObjects.Length];
        for (int i = 0; i < _bannedBundle.PickableObjects.Length; i++)
        {
            bannedIdentifiers[i] = _bannedBundle.PickableObjects[i].Identifier;
        }

        return bannedIdentifiers;
    }

    private PickableObject[] GenerateKit(PickableObject[] suitableBundle)
    {
        List<PickableObject> generatedKit = new List<PickableObject>();
        int generatedObjects = 0;

        int bundleLength = _selectedBundle.PickableObjects.Length;
        while (generatedObjects < _amountToGenerate)
        {
            PickableObject suggestedObject = _selectedBundle.PickableObjects[Random.Range(0, bundleLength)];
            if (!generatedKit.Contains(suggestedObject))
            {
                generatedKit.Add(suggestedObject);
                generatedObjects++;
            }
        }
        var suitableObject = suitableBundle[Random.Range(0, suitableBundle.Length)];
        if (!generatedKit.Contains(suitableObject))
        {
            generatedKit[Random.Range(0, generatedKit.Count)] = suitableObject;
        }
        return generatedKit.ToArray();
    }
}
