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

    public PlayerData (Player player)
    {
        level = player.level;
        coin = player.coin;
        sfx = player.sfx;
        music = player.music;
    }
}
