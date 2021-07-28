using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageHandler : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    public void FadeIn()
    {
        _image.FadeIn();
    }

    public void FadeOut()
    {
        _image.FadeOut();
    }
}
