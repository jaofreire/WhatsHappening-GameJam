using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMonster : MonoBehaviour
{
    [SerializeField] private AudioSource CameraSourceBackGround;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            MoveMonster.instance.Move();

            CameraSourceBackGround.clip = Audios.instance.BackGroundMonster;
            CameraSourceBackGround.loop = true;
            CameraSourceBackGround.Play();
           
        }
    }
}
