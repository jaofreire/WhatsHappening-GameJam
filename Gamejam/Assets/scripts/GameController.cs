using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform Player;
    [SerializeField] private Transform SpawnPlayer;

    [SerializeField] private GameObject MoveTutorial;
    //[SerializeField] private GameObject JumpTutorial;
    //[SerializeField] private GameObject RunTutorial;
    //[SerializeField] private GameObject CrouchTutorial;

    [Header("Audio")]
    [SerializeField] private AudioSource PlayerSource;
    [SerializeField] private AudioSource CameraSource;

    public static GameController instance;

    void Awake()
    {
        instance = this;
        StartCoroutine(Move());

        //Player.transform.position = SpawnPlayer.transform.position;

        if (MenuController.instance.AudioListenerOn)
        {
            PlayerSource.mute = false;
            CameraSource.mute = false;
        }

        if (!MenuController.instance.AudioListenerOn)
        {

            PlayerSource.mute = true;
            CameraSource.mute = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DestroyObject(GameObject Obj)
    {
        Destroy(Obj);
    }

    public void DesactiveTutorialMove()
    {
        MoveTutorial.SetActive(false);
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(3.5f);
        DesactiveTutorialMove();
    }

}
