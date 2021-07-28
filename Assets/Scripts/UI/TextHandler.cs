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
    }
}
