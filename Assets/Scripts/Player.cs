using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Questions Questions;

    public int level = 1;
    public int coin = 100;
    public bool sfx = false;
    public bool music = false;
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

        level = (data != null) ? data.level : level;
        coin = (data != null) ? data.coin : coin;
        sfx = (data != null) ? data.sfx : sfx;
        music = (data != null) ? data.music : music;
        qlue1 = (data != null) ? data.qlue1 : qlue1;
        qlue2 = (data != null) ? data.qlue2 : qlue2;
        qlue3 = (data != null) ? data.qlue3 : qlue3;
        qlue4 = (data != null) ? data.qlue4 : qlue4;
        qlue5 = (data != null) ? data.qlue5 : qlue5;
        qlue6 = (data != null) ? data.qlue6 : qlue6;
        //for (int i = 0; i < qlue.Length; i++)
        //{
        //    qlue[i] = (data != null) ? data.qlue[i] : qlue[i];
        //}
    }

    #region UI Methods

    public void ChangeLevel (int amount)
    {
        level += amount;
    }

    #endregion
}
