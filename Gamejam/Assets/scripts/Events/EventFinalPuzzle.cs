using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFinalPuzzle : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private GameObject Obj;
    [SerializeField] private Transform EventPoint;
    [SerializeField] private float Y;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Fall();
    }

    void Fall()
    {
       
        float distance = Vector2.Distance(Player.position, EventPoint.position);

        if (distance < 5)
        {
            StartCoroutine(Count());
        }
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(5f);
        Obj.transform.DOMoveY(Y, 4);
        Destroy(Obj, 3.5f);
        StopAllCoroutines();
    }
}
