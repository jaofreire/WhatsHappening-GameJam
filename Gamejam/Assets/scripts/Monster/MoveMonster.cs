using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    private Rigidbody2D Rig;
    [SerializeField] private float Vel;
    [SerializeField] private int Damage;

    public static MoveMonster instance;
   
    void Start()
    {
        instance = this;
        Rig = GetComponent<Rigidbody2D>();
    }


    public void Move()
    {
        Rig.velocity = new Vector2(Vel, Rig.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            CheckPoint.instance.ReturnCheckPoint();
        }
    }
}
