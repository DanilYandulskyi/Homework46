using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBar : HealthUI
{
    [SerializeField] private Image _image;
    [SerializeField] private MovingBar _movingBarType;
    [SerializeField] private float _changingSpeed;

    private float _target;

    protected override void UpdateUI()
    {
        _target = Health.CurrentValue / Health.MaxValue;
        StartCoroutine(ChangeBar());
    }

    private IEnumerator ChangeBar()
    {
        while (_image.fillAmount != _target)
        {
            if (_movingBarType == MovingBar.Gradually)
            {
                _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _target, _changingSpeed * Time.deltaTime);
            }
            else
            {
                _image.fillAmount = _target;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}

enum MovingBar
{
    Instantly,
    Gradually
}