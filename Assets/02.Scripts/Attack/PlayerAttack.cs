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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(curtime <= 0)
        {
            if (Input.GetKey(KeyCode.Q) && gameObject.layer == 11)
            {
                if(spriteRenderer.flipX == false)
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
