using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ObjectPooler objectPooler;
    FireBall fireBall;
    Player player;
    EnemySpawner enemySpawner;
    [SerializeField] int health = 200;
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    
    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        objectPooler = FindObjectOfType<ObjectPooler>();
        fireBall = FindObjectOfType<FireBall>();
        player = FindObjectOfType<Player>();

        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }
    private void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }
    private void Fire()
    {
        if (player)
        {
            GameObject projectile =
        objectPooler.SpawnFromPool(
        "enemyfire",
        transform.position,
        Quaternion.identity);

            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("FireBall"))
        {
            health -= fireBall.GetDamage();
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                enemySpawner.enemyCount--;
                Destroy(gameObject);
            }
        }
    }
}
