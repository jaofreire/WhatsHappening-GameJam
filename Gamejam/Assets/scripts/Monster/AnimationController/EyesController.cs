using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    private Animator Animation;
    // Start is called before the first frame update
    void Start()
    {
        Animation = GetComponent<Animator>();
        StartCoroutine(TimeAnimation());
    }

    // Update is called once per frame
    IEnumerator TimeAnimation()
    {
        yield return new WaitForSeconds(2f);
       float random = Random.Range(0, 3);

        if (random < 2)
        {
            Animation.SetBool("Transition", true);
        }
        else
        {
            Animation.SetBool("Transition",false);
        }
        StartCoroutine(TimeAnimation());
    }
}
