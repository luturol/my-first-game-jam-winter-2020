using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemies;
    public GameObject Target;
    public GameObject HealthBar;

    //Wave settings
    private float lastSpawn = 2f;
    private float waitNextWave = 5f;
    private float waited = 0f;
    private int spawnPerWave = 1;
    private int spawned = 0;
    private List<int> fibonacciWave;
    public Text waveCountText;
    private bool waveEnded = false;

    private void Start()
    {
        fibonacciWave = new List<int> { spawnPerWave };        
    }

    // Update is called once per frame
    void Update()
    {
        waveCountText.text = "Wave: " + fibonacciWave.Count;
        Spawn();        
    }

    private void Spawn()
    {
        waited += Time.deltaTime;

        if(waveEnded == true && waited > waitNextWave)
        {
            InstantiateEnemy();
            waveEnded = false;
        }
        else if (lastSpawn < waited && spawned < spawnPerWave  && waveEnded == false)
        {
            InstantiateEnemy();
        }
        else if(spawned == spawnPerWave)
        {
            waveEnded = true;
            CreateNewWave();
        }
    }

    private void InstantiateEnemy()
    {
        waited = 0;
        spawned += 1;

        var health = Instantiate(HealthBar) as GameObject;
        var enemy = Instantiate(Enemies) as GameObject;

        enemy.GetComponent<EnemyAI>().target = Target.transform;

        var sliderRef = health.GetComponentInChildren<Slider>();
        sliderRef.GetComponent<FollowTransform>().SetFollowingObject(enemy.transform);

        enemy.GetComponent<Enemy>().SetHealthBar(sliderRef);

        health.transform.SetParent(enemy.transform);
    }

    private void CreateNewWave()
    {
        if (spawned == spawnPerWave && fibonacciWave.Count == 1)
        {
            spawned = 0;
            spawnPerWave = fibonacciWave[fibonacciWave.Count - 1] + fibonacciWave[fibonacciWave.Count - 1];
            fibonacciWave.Add(spawnPerWave);
        }
        else if (spawned == spawnPerWave && fibonacciWave.Count < 4 && fibonacciWave.Count > 1)
        {
            spawned = 0;
            spawnPerWave = fibonacciWave[fibonacciWave.Count - 1] + fibonacciWave[fibonacciWave.Count - 2];
            fibonacciWave.Add(spawnPerWave);
        }

        if(fibonacciWave.Count == 4 && waveEnded)
        {
            SceneManager.LoadScene("menu");
        }
    }
}
