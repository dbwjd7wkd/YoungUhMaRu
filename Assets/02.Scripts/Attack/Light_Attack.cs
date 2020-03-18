using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Attack : MonoBehaviour
{
    public float speed;

    public float distance;
    public LayerMask isLayer;

    PlayerAttack Key;

    RaycastHit2D ray;

    void Start()
    {
        Invoke("DestroyLight_Attack", 2);
        Key = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.right * (distance), new Color(0, 1, 0));
        ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);

        if (transform.rotation.y == 0) //오른쪽 볼 때 오른쪽으로 발사
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else //왼쪽 볼 때 왼쪽으로 발사
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }

        if (ray.collider != null) //레이어가 특정 레이어에 부딪히면 DestroyLight_Attack함수 실행
        {
            Debug.Log("맞음");
            if (ray.collider.tag == "Platform")
            {
                DestroyLight_Attack(); //발사체 없어짐
            }

            else if (ray.collider.gameObject.layer == 10 || ray.collider.gameObject.layer == 14)
            {
                Debug.Log("맞음2");
                StopAllCoroutines();
                StartCoroutine(Damaged());
            }

        }
    }

    //발사체 없어짐
    void DestroyLight_Attack()
    {
        Destroy(gameObject);
    }

    IEnumerator Damaged()
    {
                switch (Key.key)
                {
                    case "q":
                        if (ray.collider.gameObject.tag == "January")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "1월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "w":
                        if (ray.collider.gameObject.tag == "February")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "2월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "e":
                        if (ray.collider.gameObject.tag == "March")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "3월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "r":
                        if (ray.collider.gameObject.tag == "April")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "4월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "a":
                        if (ray.collider.gameObject.tag == "May")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "5월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "s":
                        if (ray.collider.gameObject.tag == "June")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "6월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "d":
                        if (ray.collider.gameObject.tag == "July")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "7월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "f":
                        if (ray.collider.gameObject.tag == "August")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "8월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "z":
                        if (ray.collider.gameObject.tag == "September")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "9월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "x":
                        if (ray.collider.gameObject.tag == "October")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "10월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "c":
                        if (ray.collider.gameObject.tag == "November")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "11월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;

                    case "v":
                        if (ray.collider.gameObject.tag == "December")
                        {
                            DestroyLight_Attack(); //발사체 없어짐
                            ray.collider.gameObject.GetComponent<EnemyStat>().EnemyDamaged(transform.position, "12월"); //몬스터 체력, 죽음, 데미지 관리
                        }
                        break;
                }
        yield return new WaitForSecondsRealtime(Time.timeScale);
    }
}
