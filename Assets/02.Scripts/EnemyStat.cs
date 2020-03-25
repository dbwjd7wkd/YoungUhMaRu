using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStat : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Image img;

    public int hp;
    public int currentHp;

    public GameObject healthBarBackground;
    public Image healthBarFilled;

    public GameObject Light_Star;

    PlayerStat playerHP;
    StageManager makeportal;

    AudioSource audioSource; // 음악플레이어
    public AudioClip twinkleSound; // 별 효과음
    public AudioClip attackSound; // 공격 효과음

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        makeportal = GameObject.Find("TransferPoint").GetComponent<StageManager>();

        if (gameObject.layer == 10)
        {
            currentHp = hp;
            healthBarFilled.fillAmount = 1f;
            playerHP = GameObject.Find("Health").GetComponent<PlayerStat>();
        }
    }
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
    }

    public void EnemyDamaged(Vector2 targetPos, string word)
    {
        if (gameObject.layer == 10)
        {
            if (currentHp == 1)
            {
                //몬스터 죽음
                audioSource.clip = attackSound; // 공격효과음
                audioSource.Play();

                StopAllCoroutines();
                anim.SetBool("Die", true); // Die 애니메이션
                Invoke("MakePortal", 0.9f); //몬스터 다 죽이면 다음스테이지 포탈 생성
                Destroy(gameObject, 0.9f); // 몬스터 없앰
                GameObject lightStar = Instantiate(Light_Star); // 별빛 효과
                lightStar.transform.position = rigid.transform.position;
                playerHP.MyCurrentValue += 1; //Player hp 1 상승
                Destroy(lightStar, 1f); //별빛 효과 없앰
            }
            else
            {
                currentHp -= 1; //몬스터 체력조절: -hp

                //View Alpha
                spriteRenderer.color = new Color(225 / 255f, 205 / 255f, 255 / 255f, 0.9f);

                ////Reaction Force
                int dirc = transform.position.x - targetPos.x < 0 ? 1 : -1;
                rigid.AddForce(new Vector2(dirc, 1) * 2, ForceMode2D.Impulse);

                audioSource.clip = attackSound; // 공격효과음
                audioSource.Play();

                EnemyFloatingText(word); //데미지처럼 영어단어 띄우기

                //몬스터 체력바 나타내기
                healthBarFilled.fillAmount = (float)currentHp / hp;
                healthBarBackground.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(WaitCoroutin());
            }
        }
        else 
        {
            //Star light
            GameObject lightStar = Instantiate(Light_Star);
            lightStar.transform.position = rigid.transform.position;

            //View Alpha
            img.color = new Color(1f, 1f, 1f, 1f);

            //Change Layer
            gameObject.layer = 15;

            audioSource.clip = twinkleSound; // 공격효과음
            audioSource.Play();

            //데미지처럼 영어단어 띄우기
            EnemyFloatingText(word);

            Invoke("MakePortal_Star", 3f); //별 다 맞추면 다음스테이지 포탈 생성
        }      
    }

    public GameObject prefabs_Floating_Text;
    public Transform parent;
    void EnemyFloatingText(string word)
    {
        //AudioManager.instance.Play(atkSound);

        GameObject clone = Instantiate(prefabs_Floating_Text);
        clone.transform.position = parent.position;
        Debug.Log("EnemyFloatingText");

        if (gameObject.layer == 10)
            clone.transform.GetChild(0).GetComponent<FloatingText>().text.text = word;
        else if(gameObject.layer == 14)
            clone.transform.GetChild(0).GetComponent<FloatingText>().text.text = gameObject.tag;
        //clone.GetComponent<FloatingText>().text.color = Color.red;
        //clone.GetComponent<FloatingText>().text.fontSize = 1;

        Destroy(clone, 7f);
    }

    //몬스터 체력바 나타내기
    IEnumerator WaitCoroutin()
    {
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(2f);
        healthBarBackground.SetActive(false);
    }

    void MakePortal()
    {
        makeportal.MakePortal1();
    }

    void MakePortal_Star()
    {
        makeportal.MakePortal2();
    }

}
