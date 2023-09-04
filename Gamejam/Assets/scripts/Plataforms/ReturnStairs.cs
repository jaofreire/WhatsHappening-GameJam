using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnStairs : MonoBehaviour
{
    [SerializeField] private Transform ReturnPoint;

    public void Respawn()
    {
        transform.position = ReturnPoint.position;
    }
}
