using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_move : MonoBehaviour {
    public float ScrollSpeed = 1.0f;    //배경속도 값 저장변수
    float Offset;                       //배경이동 좌표값 저장변수
    private new Renderer renderer;      

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        Offset += Time.deltaTime * ScrollSpeed; //매 프레임마다 배경의 좌표를 움직여준다
        renderer.material.mainTextureOffset = new Vector2(0, Offset);   //배경의 좌표에 y축으로 offset만큼 이동한 좌표를 계속 대입
	}
}
