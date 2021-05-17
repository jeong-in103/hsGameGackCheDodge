﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성할 탄알의 원본 프리맵
    public float spawnRateMIn = 0.5f; //최소 생성 주기
    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; //발사할 대상
    private float spawnRate; //생성주기
    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMIn, spawnRateMax); //생성주기

        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMIn, spawnRateMax);
        }
    }
}
