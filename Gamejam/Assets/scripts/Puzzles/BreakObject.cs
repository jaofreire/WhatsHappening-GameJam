using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObject : MonoBehaviour
{
    //[SerializeField] private GameObject Break;
    [SerializeField] private int LayerNumber;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerNumber || collision.gameObject.CompareTag("Door"))
        {
            Destroy(collision.gameObject);
        }
    }

}
