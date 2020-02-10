using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Component Enemies;
    public Component Target;
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
            Debug.Log("Spawned");
            waited = 0;
            spawned += 1;
            var enemy = Instantiate(Enemies);
            enemy.GetComponent<EnemyAI>().target = Target;
        }
    }

    private void CreateNewWave()
    {
        if(spawned == spawnPerWave && fibonacci.Count < 4)
        {
            spawned = 0;
            spawnPerWave = fibonacci[fibonacci.Count - 1] + fibonacci[fibonacci.Count - 2];
            fibonacci.Add(spawnPerWave);
        }
    }
}
