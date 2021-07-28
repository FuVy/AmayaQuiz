using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneAsyncLoader : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    private Button _button;

    [SerializeField]
    private SceneAsyncLoadedBehaviour _sceneBehaviour;

    private AsyncOperation _loadingOperation;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadAsync(1);

        _sceneBehaviour.enabled = true;
        _sceneBehaviour.SetAsyncOperation(_loadingOperation);

        _image.Fade(0, 0);

        //Button restartButton;
            //restartButton.onClick.AddListener(() => LoadAsync());
    }

    public void Initialize()
    {
        _button = GameObject.FindGameObjectWithTag("RestartButton").GetComponent<Button>();
        _button.onClick.AddListener(() => LoadAsync(1));
        _image.Fade(0, 0);
    }
      
    public void LoadAsync(int id)
    {
        _loadingOperation = SceneManager.LoadSceneAsync(id);
        //_image.Fade(1, 0.5f);
    }

    public void Fade(float value, float duration)
    {
        _image.Fade(value, duration);
    }
}
