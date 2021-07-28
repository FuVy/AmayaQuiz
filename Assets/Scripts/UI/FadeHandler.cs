using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeHandler : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    private void Start()
    {
        if (PlayerPrefs.GetString("afterRestart") == "true")
        {
            _image.Fade(1, 0);
            _image.Fade(0, 0.5f);
            PlayerPrefs.SetString("afterRestart", "false");
        }
    }

    public void FadeIn()
    {
        _image.FadeIn();
    }

    public void FadeOut()
    {
        _image.FadeOut();
    }
}
