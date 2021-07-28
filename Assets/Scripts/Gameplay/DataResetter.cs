using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataResetter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ApplicationQuit;
    private void Awake()
    {
        HandleCrush();
    }

    private void HandleCrush()
    {
        if (PlayerPrefs.GetString("hasCrushed") == "true")
        {
            Debug.Log("Crush detected");
            PlayerPrefs.DeleteAll();
            OnApplicationQuit();
        }
        PlayerPrefs.SetString("hasCrushed", "true");
    }

    private void OnApplicationQuit()
    {
        ApplicationQuit.Invoke();
    }
    
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
