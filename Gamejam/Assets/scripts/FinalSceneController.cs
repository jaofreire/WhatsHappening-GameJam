using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneController : MonoBehaviour
{
    [SerializeField] private AudioSource AudioScene;

    [SerializeField] public AudioClip AlarmSound;
    [SerializeField] public AudioClip FinalMusic;

    [SerializeField] private GameObject BlackPanel;

    [SerializeField] private Animator AnimPlayer;
    void Start()
    {
        AudioScene.PlayOneShot(AlarmSound);
        StartCoroutine(DestroyBlackPanel());
    }

    IEnumerator DestroyBlackPanel()
    {
        yield return new WaitForSeconds(8f);
        Destroy(BlackPanel);
        AudioScene.clip = FinalMusic;
        AudioScene.Play();
        AnimPlayer.SetTrigger("Start");
        
    }

    
}
