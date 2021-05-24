using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : MonoBehaviour
{
    [Header("Scale")]
    [SerializeField] private float _bounceScale1;
    [SerializeField] private float _bounceScale2;
    [SerializeField] private float _bounceScale3;
    [SerializeField] private float _bounceScale4;
    [Header("Time")]
    [SerializeField] private float _bounceTime1;
    [SerializeField] private float _bounceTime2;
    [SerializeField] private float _bounceTime3;
    [SerializeField] private float _bounceTime4;

    public void Emergence()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(_bounceScale1, _bounceTime1));
        sequence.Append(transform.DOScale(_bounceScale2, _bounceTime2));
        sequence.Append(transform.DOScale(_bounceScale3, _bounceTime3));
    }

    public void Disappearing(Transform elementPosition)
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(elementPosition.DOScale(_bounceScale3, _bounceTime1));
        sequence.Append(elementPosition.DOScale(_bounceScale2, _bounceTime2));
        sequence.Append(elementPosition.DOScale(_bounceScale1, _bounceTime3));
        sequence.Append(elementPosition.DOScale(_bounceScale4, _bounceTime4));
    }
}
