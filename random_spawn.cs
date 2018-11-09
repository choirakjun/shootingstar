using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_spawn : MonoBehaviour {

    public GameObject Enemy; //Prefab을 받을 public 변.
                           
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.5f, 0.5f); //1.5초후 부터, SpawnEnemy함수를 1.5초마다 반복해서 실행
    }
    void Update()
    {

    }

    void SpawnEnemy()
    {
        Vector3 position;
        position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 1); //랜덤좌표생성
        position = transform.TransformPoint(position * .5f); //로컬좌표를 월드좌표로 변환
        Instantiate(Enemy, position, transform.rotation); //생성
    }
}
