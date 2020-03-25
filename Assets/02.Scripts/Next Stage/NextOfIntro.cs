using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextOfIntro : MonoBehaviour
{
    Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        // 정확하게 애니메이션 시작
        // 애니메이션 위치를 초기화 하고, 애니메이션 이름으로 Play
        //ani.Rebind();
        ani.Play("intro");
        Debug.Log("1");
    }

    // Update is called once per frame
    void Update()
    {
        // 애니메이션 종료는 Coroutine으로 확인하자
        // 끝났는지 확인(시간이 normalized 되어서 0.0f~1.0f를 가짐)
        if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Debug.Log("3");
            SceneManager.LoadScene(1);
        }
        Debug.Log("2");

    }
}
