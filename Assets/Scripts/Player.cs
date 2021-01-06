using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int coin = 100;
    public bool sfx = false;
    public bool music = false;
    public string qlue = "0,0,0,0,0,0";

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        if (data != null)
        {
            level   = data.level;
            coin    = data.coin;
            sfx     = data.sfx;
            music   = data.music;
            qlue   = data.qlue;
        }
    }

    #region UI Methods

    public void ChangeLevel (int amount)
    {
        level += amount;
    }

    #endregion
}

/**
 * Dibuat dari 0 menggunakan Unity 2019.4 Personal
 * Programmer: Bagus Pangestu
 * Contact: baguspangestu@yandex.com
 * Project: https://github.com/baguspangestu/kbb
*/