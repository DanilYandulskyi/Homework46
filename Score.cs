using UnityEngine;

[RequireComponent(typeof(UI))]
public class Score : MonoBehaviour
{
    private int _count;
    private UI _ui;

    private void Awake()
    {
        _ui = GetComponent<UI>();
    }

    public void Increase(int count)
    {
        _count += count;
        _ui.UpdateText(_count.ToString());
    }
}