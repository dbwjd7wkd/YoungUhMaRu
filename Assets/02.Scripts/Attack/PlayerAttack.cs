using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Light_Attack;
    public Transform posRight;
    public Transform posLeft;
    public float cooltime;
    private float curtime;
    SpriteRenderer spriteRenderer;

    public string key;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(curtime <= 0)
        {
            key = Input.inputString;
            //공격키 누르면 발사체 생성
            if ((key == "q" || key == "w" || key == "e" || key == "r" || key == "a" || key == "s"
                || key == "d" || key == "f" || key == "z" || key == "x" || key == "c" || key == "v") && gameObject.layer == 11)
            {
                if (spriteRenderer.flipX == false)
                {
                    Instantiate(Light_Attack, posRight.position, posRight.transform.rotation);
                }
                else
                {
                    Instantiate(Light_Attack, posLeft.position, posLeft.transform.rotation);
                }
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;
    }
}
