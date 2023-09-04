using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObjectsDirec : MonoBehaviour
{
    private Rigidbody2D Rig;

    [SerializeField] private float VelX;

    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Rig.velocity = new Vector2(-VelX,Rig.velocity.y);
        Destroy(gameObject, 10f);
    }


    
}
