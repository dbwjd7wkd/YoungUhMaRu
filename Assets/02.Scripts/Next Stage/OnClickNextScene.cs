using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OnClickNextScene : MonoBehaviour
{
    public void GoStage1_0()
    {
        SceneManager.LoadScene("Stage1-0");
    }

    public void GoStage1_1()
    {
        SceneManager.LoadScene("Stage1-1");
    }

    public void GoStage1_2()
    {
        SceneManager.LoadScene("Stage1-2");
    }

    public void GoStage1_3()
    {
        SceneManager.LoadScene("Stage1-3");
    }
    public void GoStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void GoOutro()
    {
        SceneManager.LoadScene("Outro");
    }
}