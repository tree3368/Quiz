using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

[RequireComponent(typeof(Bounce))]
public class Box : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ParticleSystem _stars;

    private char _element;
    private Bounce _bounce;
    private bool _result;

    public event UnityAction<Box, char> CheckValue;
    public event UnityAction LevelPassed;

    public void InstallObject(char element)
    {
        _element = element;
        _text.text = _element.ToString();
    }

    private void Start()
    {
        _bounce = GetComponent<Bounce>();
        _bounce.Emergence();
    }

    private void OnMouseDown()
    {
        CheckValue?.Invoke(this, _element);
        if (_result)
        {
            _bounce.Disappearing(_text.transform);
            _stars.Play();
            LevelPassed?.Invoke();
        }
        else
        {
            _text.transform.DOShakePosition(1, new Vector3(0.5f, 0), 5, 0);
        }
    }

    public void GetResult(bool result)
    {
        _result = result;
    }
}
