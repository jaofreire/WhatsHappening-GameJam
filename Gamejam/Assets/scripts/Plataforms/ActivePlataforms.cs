using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlataforms : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private  Transform EventPoint;
    [SerializeField] private List<GameObject> Plataforms = new List<GameObject>();
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            foreach (GameObject elements in Plataforms)
            {
                MovePlataforms PlataformsMoves = elements.GetComponent<MovePlataforms>();

                if (PlataformsMoves == null) return;

                if (PlataformsMoves != null)
                {
                    PlataformsMoves.Active();
                }
            }
        }
    }
}
