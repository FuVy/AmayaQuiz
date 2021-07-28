using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextHandler : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;
    public void ChangeText(string text)
    {
        _text.text = text;
        if (PlayerPrefs.GetString("alreadyInitialized") != "true")
        {
            Color color = _text.color;
            _text.color = new Color(color.a, color.g, color.b, 0f);
            FadeIn();
        }
    }

    public void FadeIn()
    {
        _text.FadeIn();
    }

    public void FadeOut()
    {
        _text.FadeOut();
    }
}
