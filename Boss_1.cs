using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    private Boss_Data bossData;
    public int bossHP;      //보스 총HP
    public int phase2HP;    //보스 제 2패턴 시작HP
    public int phase3HP;    //보스 제 3패턴 시작HP
    public float shot;      //1패턴 발사 미사일 개수
    public float speed;     //탄이 날라가는 속도
    public GameObject bullet;
    public GameObject boss1;
    public GameObject plane;
    public GameObject explosion;
    public float shotAngle;
    public float shotAngleRate;
    private int level;      //패턴 시작 조건 
    Coroutine spell1;
    Coroutine spell2;
    Coroutine spell3;
    Coroutine spell4;
    GameObject obj;

    // Use this for initialization
    void Start()
    {
        bossData = new Boss_Data(bossHP);
        Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        level = 1;
    }

    void Update()
    {
        //1패턴 시작
        if (bossData.getHP() == bossHP && level == 1)
        {
            spell1 = StartCoroutine(BulletSpell1());
            level++;
        }
        //1패턴 종료후 2패턴 시작
        if (bossData.getHP() <= phase2HP && level == 2)
        {
            StopCoroutine(spell1);
            spell2 = StartCoroutine(BulletSpell2());
            level++;
        }
        //2패턴 종료후 1,3패턴 시작
        if (bossData.getHP() <= phase3HP && level == 3)
        {
            StopCoroutine(spell2);
            spell3 = StartCoroutine(BulletSpell1());
            spell4 = StartCoroutine(BulletSpell3());
            level++;
        }
        //체력이 0이 되면 1,3패턴 종료후 오브젝트  제거
        if (bossData.getHP() <= 0)
        {
            StopCoroutine(spell3);
            StopCoroutine(spell4);
            Instantiate(explosion,boss1.transform.position,Quaternion.identity);    //폭발 이팩트
            Destroy(explosion);
            Destroy(boss1);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Missile 태그를 가진 오브젝트와 충돌시 HP감소
        if(col.CompareTag("Missile"))
        {
            bossData.decreaseHP(1);
            Debug.Log(gameObject.name + "의 체력: " + bossData.getHP());
        }
    }

    IEnumerator BulletSpell1()
    {
        do
        {
            yield return new WaitForSeconds(1.2f);
            for (int i = 0; i < shot; i++)
            {
                //보스 위치에 탄 생성
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //bullet을 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot), speed * Mathf.Sin(Mathf.PI * i * 2 / shot)));
            }

            yield return new WaitForSeconds(1.2f);
            for (int i = 0; i < shot; i++)
            {
                obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

                //각도를 수정해서 bullet을 원형으로 발사
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * 2 * i / shot + Mathf.PI / 2), speed * Mathf.Sin(Mathf.PI * i * 2 / shot + Mathf.PI / 2)));
            }
        } while (true);
    }

    IEnumerator BulletSpell2()
    {
        float angle;
        int rotate;
        angle = 0;
        rotate = 0;
        do
        {
            obj = Instantiate(bullet, boss1.transform.position, Quaternion.identity);

            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Mathf.Cos(Mathf.PI * angle), speed * Mathf.Sin(Mathf.PI * angle)));

            if (angle > 2)
            {
                angle = 0;
            }
            if (angle < 2)
            {
                //발사 각도 변화
                angle += shotAngle;
            }

            if (rotate == 0)
            {
                //탄 생성각 증가
                shotAngle += shotAngleRate;
                shotAngleRate += shotAngleRate / 500;
                if (shotAngle > 0.15)
                {
                    rotate = 1;
                }
            }

            if (rotate == 1)
            {
                //탄 생성각 감소
                shotAngle -= shotAngleRate;
                shotAngleRate -= shotAngleRate / 500;
                if (shotAngle < 0.05)
                {
                    rotate = 0;
                }
            }

            yield return new WaitForSeconds(0.018f);
        } while (true);
    }

    IEnumerator BulletSpell3()
    {
        Vector2 v;
        do
        {
            obj = (GameObject)Instantiate(bullet, boss1.transform.position, Quaternion.identity);

            v = plane.transform.position - boss1.transform.position;    //보스->플레이어 방향
            obj.GetComponent<Rigidbody2D>().AddForce(v.normalized * speed);

            yield return new WaitForSeconds(0.29f);
        } while (true);
    }
}