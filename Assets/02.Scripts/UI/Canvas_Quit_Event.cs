using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_Quit_Event : MonoBehaviour
{
    public void OnClickYes()
    {
        Application.Quit();
    }
}
