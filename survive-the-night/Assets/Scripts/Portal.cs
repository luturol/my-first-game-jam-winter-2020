using System.Threading;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int life;
    public Transform PortalActivationArea;
    public float PortalActivationRange;
    public LayerMask enemyLayers;
    public Text timeCount;
    public Transform pfDamagePopup;

    private int minuts;
    private float seconds;

    void Start()
    {
        if (life == 0)
            life = 10;
    }

    void Update()
    {
        seconds = seconds + Time.deltaTime;

        if (seconds >= 60)
        {
            minuts++;
            seconds = 0;
        }

        timeCount.text = minuts.ToString("00") + ":" + ((int)seconds).ToString("00");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PortalActivationArea.position, PortalActivationRange, enemyLayers);

        foreach (Collider2D enemyCollided in hitEnemies)
        {
            var enemy = enemyCollided.GetComponent<Enemy>();
            enemy.TakeDamage(enemy.maxHealth, new Vector2(transform.position.x, transform.position.y));
            life--;
            Transform damagePopupTransform = Instantiate(pfDamagePopup, transform.position, Quaternion.identity);
            DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
            damagePopup.Setup(-1);
        }


        if (life == 0)
        {
            SceneManager.LoadScene("menu");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Treant" + other.gameObject.name);
    }

    private void OnDrawGizmosSelected()
    {
        if (PortalActivationArea == null)
            return;

        Gizmos.DrawWireSphere(PortalActivationArea.position, PortalActivationRange);
    }
}
