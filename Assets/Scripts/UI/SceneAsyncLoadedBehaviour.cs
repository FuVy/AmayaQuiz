using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneAsyncLoadedBehaviour : MonoBehaviour
{
    [SerializeField]
    private UnityEvent SceneLoaded;

    private AsyncOperation _loadingOperation;
    bool invoked = false;
    void Update()
    {
        if (_loadingOperation != null)
        {
            if (_loadingOperation.isDone)
            {
                if (!invoked)
                {
                    Debug.Log("invoked");
                    SceneLoaded.Invoke();
                    invoked = true;
                }
            }
        }
    }

    public void SetAsyncOperation(AsyncOperation loadingOperation)
    {
        _loadingOperation = loadingOperation;
    }
}
