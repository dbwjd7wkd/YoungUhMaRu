using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //현재 씬 정보를 가지고 온다. 
            Scene scene = SceneManager.GetActiveScene();
            //현재 씬의 빌드 순서를 가지고 온다. 
            int curScene = scene.buildIndex;
            //현재 씬 바로 다음씬을 가져오기 위해 +1을 해준다. 
            int nextScene = curScene + 1;
            //다음씬을 불러온다. 
            SceneManager.LoadScene(nextScene);
        }
    }
}
