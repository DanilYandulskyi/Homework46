using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
    }
}