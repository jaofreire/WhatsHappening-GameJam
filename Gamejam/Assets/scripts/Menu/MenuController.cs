using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private int SceneNumber;

    [Header("Options")]
    [SerializeField] private GameObject OptionMenu;
    [SerializeField] private GameObject ButtonSoundON;
    [SerializeField] private GameObject ButtonSoundOFF;
    [SerializeField] public AudioSource MenuSource;
    [SerializeField] public bool AudioListenerOn = true;
    [SerializeField] private AudioListener Listener;

    [Header("Pause")]
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private int SceneMenu;


    public static MenuController instance;
    private void Start()
    {
        instance = this;
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneNumber);
        MenuSource.PlayOneShot(Audios.instance.ClickButton);
    }

    public void Quit()
    {
        Application.Quit();
        MenuSource.PlayOneShot(Audios.instance.ClickButton);
    }

    public void Options()
    {
        OptionMenu.SetActive(true);
        MenuSource.PlayOneShot(Audios.instance.ClickButton);
    }

    public void ExitOptions()
    {
        OptionMenu.SetActive(false);
        MenuSource.PlayOneShot(Audios.instance.ClickButton);
    }

    public void SoundOFF()
    {
        ButtonSoundON.SetActive(false);
        ButtonSoundOFF.SetActive(true);
        AudioListenerOn = false;
        Listener.enabled = false;
        MenuSource.PlayOneShot(Audios.instance.ClickButton);
    }

    public void SoundON()
    {
        ButtonSoundON.SetActive(true);
        ButtonSoundOFF.SetActive(false);
        AudioListenerOn = false;
        Listener.enabled = true;
        MenuSource.PlayOneShot(Audios.instance.ClickButton);

    }


    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneMenu);
    }
    public void Despause()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

}
