using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataforms : MonoBehaviour
{
    private BoxCollider2D BoxCollider;
    private SpriteRenderer Sprite;
    [SerializeField] private float Time;
    //[SerializeField] private float Y;
    //[SerializeField] private float YBack;
    //[SerializeField] private float Duration;
    //[SerializeField] private float DurationBack;

    
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Sprite = GetComponent<SpriteRenderer>();
    }

    public void Active()
    {
        StartCoroutine(TimeMove());
    }

    IEnumerator TimeMove()
    {
        BoxCollider.enabled = false;
        Sprite.enabled = false;
        yield return new WaitForSeconds(Time + 2);
        BoxCollider.enabled = true;
        Sprite.enabled = true;
        yield return new WaitForSeconds(Time);
        StartCoroutine(TimeMove());


    }
}
