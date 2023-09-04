using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyObjects : MonoBehaviour
{
    [SerializeField] private List<GameObject> Mobiles = new List<GameObject>();
    [SerializeField] private List<Transform> SpawnPoints = new List<Transform>();
    [SerializeField] private float Time;
    //[SerializeField] private float VelX;
    //[SerializeField] private float VelY;


    private void Start()
    {
        StartCoroutine(TimeSpawn());
    }
    

    public void SpawnMobiles()
    {
        int random = Random.Range(0, Mobiles.Count);
        Instantiate(Mobiles[random], SpawnPoints[random].position, SpawnPoints[random].rotation);

    }

    IEnumerator TimeSpawn()
    {

        yield return new WaitForSeconds(Time);
        SpawnMobiles();
        StartCoroutine(TimeSpawn());

    }


}
