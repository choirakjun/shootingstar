using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
	public int HP;

	private Enemy_Data enemyData;


	void Start(){
		enemyData = new Enemy_Data (HP);
	}
	void Update(){
		if (enemyData.getHP () <= 0) {
			Destroy (gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){
		if (collision.CompareTag ("Missile")) {
			Debug.Log ("미사일과 충돌");
			enemyData.decreaseHP (10);
		}
	}
}
