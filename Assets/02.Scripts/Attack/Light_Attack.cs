using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Attack : MonoBehaviour
{
    public float speed;

    public float distance;
    public LayerMask isLayer;

    void Start()
    {
        Invoke("DestroyLight_Attack", 2);
    }

    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if(ray.collider != null) //레이어가 특정 레이어에 부딪히면 DestroyLight_Attack함수 실행
        {
            if(ray.collider.tag == "Platform")
            {
                DestroyLight_Attack();
            }
            if(ray.collider.tag == "Enemy1") //부딪힌 물체 태그가 Enemy일 때 로그 띄우기
            {
                Debug.Log("명중!!!");
                DestroyLight_Attack();
                Destroy(ray.collider.gameObject);
            }

        }

        if(transform.rotation.y == 0) //오른쪽 볼 때 오른쪽으로 발사
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else //왼쪽 볼 때 왼쪽으로 발사
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
    }

    void DestroyLight_Attack()
    {
        Destroy(gameObject);
    }
}
