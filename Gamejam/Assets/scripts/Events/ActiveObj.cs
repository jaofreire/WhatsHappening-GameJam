using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObj : MonoBehaviour
{
    [SerializeField] List<GameObject> Objs = new List<GameObject>();
    [SerializeField] private Transform EventPoint;
    [SerializeField] private float Limit;

    private Transform Player;

    // Update is called once per frame
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    private void Update()
    {
        Active(Objs);
    }

    void Active(List<GameObject> obj)
    {
        float distance = Vector2.Distance(Player.position, EventPoint.position);

        foreach (GameObject elements in obj)
        {
            if (distance < Limit)
            {
                elements.SetActive(true);
            }
        }
    }
}
