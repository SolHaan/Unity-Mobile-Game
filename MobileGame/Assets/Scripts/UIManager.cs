using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public void GamePause()
    {
        Time.timeScale = 0;
    }

    public void GamePlay()
    {
        Time.timeScale = 1;
    }
}
