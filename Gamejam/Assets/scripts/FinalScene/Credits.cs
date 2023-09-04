using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    [SerializeField] private RectTransform creditsText;

    public void UpCredits()
    {
        creditsText.DOMoveY(330, 7);
    }
}
