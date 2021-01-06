using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Questions Questions;

    public int level = 1;
    public int coin = 100;
    public bool sfx = false;
    public bool music = false;
    public string qlue = "0,0,0,0,0,0";
    public int qlue1 = 0;
    public int qlue2 = 0;
    public int qlue3 = 0;
    public int qlue4 = 0;
    public int qlue5 = 0;
    public int qlue6 = 0;

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
            ////////////////////
            qlue    = data.qlue;
            ////////////////////
            qlue1 = data.qlue1;
            qlue2 = data.qlue2;
            qlue3 = data.qlue3;
            qlue4 = data.qlue4;
            qlue5 = data.qlue5;
            qlue6 = data.qlue6;
        }
    }

    #region UI Methods

    public void ChangeLevel (int amount)
    {
        level += amount;
    }

    #endregion
}
