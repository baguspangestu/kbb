using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 1;
    public int coin = 100;
    public bool sfx = false;
    public bool music = false;
    //public int[] qlue = new int[] {0,0,0,0,0,0};

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
    }

    #region UI Methods

    public void ChangeLevel (int amount)
    {
        level += amount;
    }

    #endregion
}
