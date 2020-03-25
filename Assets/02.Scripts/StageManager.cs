using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public int nextStage = 0;

    public GameObject Portal;

    public void MakePortal1()
    {
        nextStage++;
        if (nextStage == 12)
        {
            GameObject portal = Instantiate(Portal);
            portal.transform.position = transform.position;
        }
    }

    public void MakePortal2()
    {
        nextStage++;
        if (nextStage == 12)
        {
            GameObject portal = Instantiate(Portal);
            portal.transform.position = transform.position;
            Invoke("Transfer", 6f);
        }
    }

    public void Transfer()
    {
        Debug.Log("나옴");
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
