using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Bounce : MonoBehaviour, IPointerEnterHandler
{
    public float bounceDuration = 1f;
    public float bounceStrength = 1f;
    public float bounceRotation = 1f;
    public int loops = -1;
    public bool onStart = false;

    private Sequence wobble;
    private bool isWobbling = false;

    private void Start()
    {
        if (onStart)
            Wobble();
    }

    private void Wobble()
    {
        if (!isWobbling) {
            isWobbling = true;
            wobble = DOTween.Sequence();
            wobble.Append(transform.DOShakeRotation(bounceDuration, bounceRotation));
            wobble.Join(transform.DOShakeScale(bounceDuration, bounceStrength)).OnComplete(StopWobblingArount);
        }
    }

    private void StopWobblingArount()
    {
        isWobbling = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if ((eventData.pointerCurrentRaycast.gameObject != null) && (eventData.pointerCurrentRaycast.gameObject.name == "ResetButton"))
        {
            Wobble();
        }
    }
}
