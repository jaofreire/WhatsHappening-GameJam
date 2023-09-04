using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallStairs : MonoBehaviour
{
    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private float Y;
    [SerializeField] private float Duration;
    [SerializeField] private float Time;

    [SerializeField] private LayerMask LayerPlayer;

    private void FixedUpdate()
    {
        CheckCollision();
    }

    void Fall()
    {
       
        transform.DOMoveY(Y, Duration);
       
    }

    public void CheckCollision()
    {
        RaycastHit2D collider = Physics2D.BoxCast(BoxCollider.bounds.center, BoxCollider.bounds.size, 0f, Vector2.down, 0.1f, LayerPlayer);

        if (collider.collider != null)
        {
            StartCoroutine(TimeFall());
        }
    }
    IEnumerator TimeFall()
    {
        yield return new WaitForSeconds(Time);
        Fall();
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
        StopCoroutine(TimeFall());
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(BoxCollider.bounds.center, BoxCollider.bounds.size);
    }
}
