using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera PlayerCamera;
    [SerializeField] private CinemachineVirtualCamera[] Cameras;

    public static SwitchCamera instance;

    void Awake()
    {
        SwitchCam(PlayerCamera);

    }

    void SwitchCam(CinemachineVirtualCamera TargetCamera)
    {

        foreach (CinemachineVirtualCamera camera in Cameras)
        {
            if (camera != null)
            {
                camera.enabled = camera == TargetCamera;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraZoneEyeMonster"))
        {
            CinemachineVirtualCamera targetCamera = collision.GetComponentInChildren<CinemachineVirtualCamera>();
            if (targetCamera != null)
            {
                SwitchCam(targetCamera);
            }

        }

        if (collision.gameObject.CompareTag("CameraMonsterRunner"))
        {
            CinemachineVirtualCamera MonsterCamera = collision.GetComponentInChildren<CinemachineVirtualCamera>();

            if (MonsterCamera != null)
            {
                SwitchCam(MonsterCamera);

            }
        }

        if (collision.gameObject.CompareTag("CameraZoneInitial"))
        {
            CinemachineVirtualCamera InitialCamera = collision.GetComponentInChildren<CinemachineVirtualCamera>();
             if (InitialCamera != null)
            {
                SwitchCam(InitialCamera);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collisionExit)
    {
        if (collisionExit.gameObject.CompareTag("CameraZoneEyeMonster"))
        {
            SwitchCam(PlayerCamera);
        }

        if (collisionExit.gameObject.CompareTag("CameraMonsterRunner"))
        {
            SwitchCam(PlayerCamera);
        }

        if (collisionExit.gameObject.CompareTag("CameraZoneInitial"))
        {
            SwitchCam(PlayerCamera);
        }
    }


}
