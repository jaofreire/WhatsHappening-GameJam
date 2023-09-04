using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteract : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private float TimeDestroy;
    private Animator Animation;


    private void Start()
    {
        Animation = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PlayerMovement.instance.OnHit(Damage);
            Animation.SetTrigger("Break");
            Destroy(gameObject, TimeDestroy);
        }

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 7)
        {
            Animation.SetTrigger("Break");
            Destroy(gameObject, 0.2f);
        }
    }
}
