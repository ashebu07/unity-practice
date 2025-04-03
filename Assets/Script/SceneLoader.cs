using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

