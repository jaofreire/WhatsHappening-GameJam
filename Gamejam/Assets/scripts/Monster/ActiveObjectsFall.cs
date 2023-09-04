using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectsFall : MonoBehaviour
{
    [SerializeField] private List<GameObject> objects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            foreach (GameObject elements in objects)
            {
                ObjetcsFall Objects = elements.GetComponent<ObjetcsFall>();

                if (Objects == null) return;

                if (Objects != null)
                {
                    Objects.Fall();
                }
            }
        }
    }
}
