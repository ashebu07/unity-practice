using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitgameUI : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("게임 종료 요청됨");
        Application.Quit();
    }
}
