using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float paddingX = 0.25f;
    [SerializeField] float paddingY = 0.25f;
    [Header("Shooting")]
    [SerializeField] float fireRate = 1f;
    [Header("Health")]
    [SerializeField] int health = 3;

    [SerializeField] ObjectPooler objectPooler;
    SpriteRenderer spriteRenderer;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetUpMoveBoundaries();
        StartCoroutine(FireContinously());
    }

    
    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        float newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingY;
    }
    IEnumerator FireContinously()
    {
        while(gameObject)
        {
            objectPooler.SpawnFromPool("fireball", transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireRate);
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("FireBall"))
        {
            health -= 1;
            Destroy(collision.gameObject);
            if (health <= 0)                
            {
                Destroy(gameObject);
            }
        }
    }
    
}
