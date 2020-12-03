using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public bool sfx;
    public bool music;

    public PlayerData (Player player)
    {
        level = player.level;
        sfx = player.sfx;
        music = player.music;
    }
}
