using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActiveTutorial : MonoBehaviour
{
    [SerializeField] private GameObject Tutorial;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Tutorial.SetActive(true);
        StartCoroutine(TimeDesactive());
    }

    IEnumerator TimeDesactive()
    {
        yield return new WaitForSeconds(3f);
        Tutorial.SetActive(false);
    }

}
