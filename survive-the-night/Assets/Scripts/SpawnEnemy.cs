using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject Enemies;
    public GameObject Target;
    public GameObject HealthBar;

    //Wave settings
    private float nextSpawn = 2f;
    private float waited = 0f;
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        waited += Time.deltaTime;
        if (waited >= nextSpawn)
            InstantiateEnemy();
    }

    private void InstantiateEnemy()
    {
        waited = 0;

        
        var enemy = Instantiate(Enemies, transform.position, Quaternion.identity) as GameObject;
        var health = Instantiate(HealthBar, enemy.transform.position, Quaternion.identity) as GameObject;        

        enemy.GetComponent<EnemyAI>().target = Target.transform;

        var sliderRef = health.GetComponentInChildren<Slider>();
        sliderRef.GetComponent<FollowTransform>().SetFollowingObject(enemy.transform);

        enemy.GetComponent<Enemy>().SetHealthBar(sliderRef);

        health.transform.SetParent(enemy.transform);
    }
}
