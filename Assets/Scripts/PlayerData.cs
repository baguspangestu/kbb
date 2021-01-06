using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int coin;
    public bool sfx;
    public bool music;
    public string qlue;

    public PlayerData (Player player)
    {
        level = player.level;
        coin = player.coin;
        sfx = player.sfx;
        music = player.music;
        qlue = player.qlue;
    }
}

/**
 * Dibuat dari 0 menggunakan Unity 2019.4 Personal
 * Programmer: Bagus Pangestu
 * Contact: baguspangestu@yandex.com
 * Project: https://github.com/baguspangestu/kbb
*/