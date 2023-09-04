using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [Header("List")]
    [SerializeField] private List<GameObject> PlataformsMoves = new List<GameObject>();

    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private float Duration;

    [Header("Player")]
    [SerializeField] private Transform EventObject;
    [SerializeField] private float Limit;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayer(Player, EventObject);
    }

    void MovePlataformY()
    {
        foreach (GameObject Plataforms in PlataformsMoves)
        {
            
            Plataforms.transform.DOMoveY(Y, Duration);
            StartCoroutine(TimeDesactive());

            IEnumerator TimeDesactive()
            {
                yield return new WaitForSeconds(1.5f);
                Plataforms.SetActive(false);
                StartCoroutine(TimeDesactive());
            }

        }
    }

    void MovePlataformX()
    {

    }


    

    void CheckPlayer(GameObject player, Transform EventObject)
    {
        float distance = Vector2.Distance(player.transform.position, EventObject.transform.position);

        if (distance < Limit)
        {
            MovePlataformY();
        }
        

    }
}
