using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockEsc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC blocked in ShopScene");
        }
    }
}
