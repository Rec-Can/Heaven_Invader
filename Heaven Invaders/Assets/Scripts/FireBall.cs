using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] int damage = 100;
    Rigidbody2D rigBody;
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rigBody.velocity = new Vector2(0, speed);
    }
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
