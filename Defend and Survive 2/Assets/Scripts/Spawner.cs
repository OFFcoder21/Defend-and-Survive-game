/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] enemyPrefabs;

    [SerializeField] private float interval = 2f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            int randSpawnPoint = Random.Range(0, SpawnPoints.Length);
            timer = 0f;
            Instantiate(enemyPrefabs[0], SpawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Spawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject[] enemyPrefabs;
    public TextMeshProUGUI waveNumber;

    [SerializeField] private float interval;
    [SerializeField]private float timer = 0f;
    [SerializeField]private int wave = 0;
    [SerializeField]private int waveEnemies = 0;
    public int waveSize;

    //break time variables
    [SerializeField]float breakTime;
    [SerializeField] float pauseBreaktime;// pause 10 seconds after every 3 waves
    [SerializeField] float pauseBreak;

    private void Update()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        timer += Time.deltaTime;

        waveTimeInterval();
        if (timer >= interval && waveEnemies > 0)
        {
            int randSpawnPoint = Random.Range(0, SpawnPoints.Length);
            timer = 0f;
            Instantiate(enemyPrefabs[randomIndex], SpawnPoints[randSpawnPoint].position, transform.rotation);
            waveEnemies--;
        }
    }

    private void waveTimeInterval()
    {
        if (waveEnemies == 0)
        {
            if (wave % 3 == 0)
            {
                pauseBreaktime += Time.deltaTime;
                if (pauseBreaktime >= 10)
                {
                    Debug.Log("10sec");
                    pauseBreaktime = 0f;
                    timer = 0f;
                    wave++;
                    waveNumber.text = wave.ToString();
                    waveEnemies = wave * waveSize;
                }

            }
            else if (timer >= breakTime)
            {
                timer = 0f;
                //pauseBreaktime = 10f;
                wave++;
                waveNumber.text = wave.ToString();
                waveEnemies = wave * waveSize;
            }

        }
    }
}


