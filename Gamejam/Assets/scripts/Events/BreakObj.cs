using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BreakObj : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private Transform EventPoint;
    [SerializeField] private List <GameObject> Obj = new List <GameObject>();
    [SerializeField] private float Limit;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Update()
    {
        
    }

    void Break()
    {
        foreach (GameObject elements in Obj)
        {
            float distance = Vector2.Distance(Player.position, EventPoint.position);

            elements.SetActive(false);

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Break();
        }
    }
}
