using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataResetter : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ApplicationQuit;

    private void OnApplicationQuit()
    {
        ApplicationQuit.Invoke();
    }
    
    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
