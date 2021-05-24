using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextFind : MonoBehaviour
{
    [SerializeField] private float _timeAppearance;
    [SerializeField] private Generator _generator;

    private Text _text;

    private void OnEnable()
    {
        _generator.ObjectSelected += OnObjectSelected;
    }

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _text.DOFade(1, _timeAppearance);
    }

    private void OnDisable()
    {
        _generator.ObjectSelected -= OnObjectSelected;
    }

    private void OnObjectSelected(char currentObject)
    {
        _text.text = "Find " + currentObject.ToString();
    }
}
