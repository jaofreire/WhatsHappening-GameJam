using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetcsFall : MonoBehaviour
{
    [SerializeField] private float Y;
    [SerializeField] private float Duration;

    public static ObjetcsFall Instance;

    private void Start()
    {
        Instance = this;
    }

    public void Fall()
    {
        transform.DOMoveY(Y, Duration);
    }
}
