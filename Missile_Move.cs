using UnityEngine;

public class Missile_Move : MonoBehaviour
{
	public float MoveSpeed;     // 미사일이 날라가는 속도
	public float DestroyYPos;   // 미사일이 사라지는 지점

	void Start(){}

	void Update () 
	{
		// 매 프레임마다 미사일이 MoveSpeed 만큼 up방향(Y축 +방향)으로 날라갑니다.
		transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
		// 만약에 미사일의 위치가 DestroyYPos를 넘어서면
		if(transform.position.y >= DestroyYPos)
		{
			// 미사일을 제거
			//Destroy(gameObject); //<--단순 미사일 제거
			GetComponent<Collider2D>().enabled=false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision){
		//부딪히는 collision을 가진 객체의 Tag가 Enemy일 경우
		if (collision.CompareTag ("Enemy")) {
			Debug.Log ("적 기체와 충돌");
            GetComponent<Collider2D> ().enabled = false;
            //Destroy(gameObject);
        }
	}

}