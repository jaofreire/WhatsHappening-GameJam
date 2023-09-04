using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Audios : MonoBehaviour
{
    public static Audios instance;
    [Header("Background")]
    [SerializeField] public AudioClip BackGroundMsc;
    [SerializeField] public AudioClip BackGroundMonster;

    [Header("Player")]
    [SerializeField] public AudioClip Walk;
    [SerializeField] public AudioClip Run;
    [SerializeField] public AudioClip Jump;
    [SerializeField] public AudioClip Hit;

    [Header("Menu")]
    [SerializeField] public AudioClip ClickButton;
    //[SerializeField] public AudioSource MenuSource;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

   
}
