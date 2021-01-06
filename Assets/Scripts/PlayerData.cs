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
    public int qlue1;
    public int qlue2;
    public int qlue3;
    public int qlue4;
    public int qlue5;
    public int qlue6;

    public PlayerData (Player player)
    {
        level = player.level;
        coin = player.coin;
        sfx = player.sfx;
        music = player.music;
        qlue = player.qlue;
        qlue1 = player.qlue1;
        qlue2 = player.qlue2;
        qlue3 = player.qlue3;
        qlue4 = player.qlue4;
        qlue5 = player.qlue5;
        qlue6 = player.qlue6;
    }
}