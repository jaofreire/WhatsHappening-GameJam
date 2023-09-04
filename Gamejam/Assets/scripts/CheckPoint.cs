using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> CheckPoints = new List<Transform>();
    [SerializeField] private List<GameObject> PlataformsStairs = new List<GameObject>();
    [SerializeField] private Transform Monster;
    [SerializeField] private Transform SpawnMonster;

    [HideInInspector]
    public Transform CurrentCheckPoint;

    public static CheckPoint instance;
    private void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            CurrentCheckPoint = collision.gameObject.GetComponent<Transform>();

            if (!CheckPoints.Contains(collision.gameObject.transform))
            {
                CheckPoints.Add(CurrentCheckPoint);
            }
           
        }
    }

    public void ReturnCheckPoint()
    {
        transform.position = CurrentCheckPoint.position;
        Monster.position = SpawnMonster.position;
        PlayerMovement.instance.ResetLife();

        foreach (GameObject elements in PlataformsStairs)
        {
            elements.SetActive(true);
            ReturnStairs Plataforms = elements.GetComponent<ReturnStairs>();

            if (Plataforms == null) return;

            if (Plataforms != null)
            {
                Plataforms.Respawn();
            }
        }
    }
}
