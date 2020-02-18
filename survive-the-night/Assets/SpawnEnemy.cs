using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemies;
    public GameObject Target;
    public GameObject HealthBar;
    private float lastSpawn = 5;
    private float waited = 0f;
    private int spawnPerWave = 1;
    private int spawned = 0;
    private List<int> fibonacci = new List<int>
    {
        1, 1
    };
    
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        CreateNewWave();
        Spawn();
    }

    private void Spawn()
    {
        waited += Time.deltaTime;

        if (lastSpawn < waited && spawned < spawnPerWave)
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
    }

    private void CreateNewWave()
    {
        if (spawned == spawnPerWave && fibonacci.Count < 4)
        {
            spawned = 0;
            spawnPerWave = fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2];
            fibonacci.Add(spawnPerWave);
        }
    }
}
