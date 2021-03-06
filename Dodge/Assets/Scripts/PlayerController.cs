using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    public int hp = 100;
    public HPBar hpBar;

    private float spawnRate = 0.2f;//플레이어는 0.2초 마다 총알 발사
    private float timerAfterSpawn;
    public GameObject playerBulletPrefab;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;
        timerAfterSpawn += Time.deltaTime;

        if(Input.GetButton("Fire1") && timerAfterSpawn >= spawnRate)
        {
            timerAfterSpawn = 0;
            GameObject bullet = Instantiate(playerBulletPrefab, transform.position, transform.rotation);
        }
    }

    void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

    public void GetDamage(int damage)
    {
        hp -= damage;
        hpBar.SetHP(hp);

        if(hp <= 0)
        {
            Die();
        }
    }

    public void GetHeal(int heal)
    {
        hp += heal;

        if(hp > 100)
        {
            hp = 100;
        }

        hpBar.SetHP(hp);
    }
}
