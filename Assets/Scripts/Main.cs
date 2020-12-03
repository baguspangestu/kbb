using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;



public class Main : MonoBehaviour
{
    [SerializeField] GameObject[] UI = new GameObject[3]; // 0 = Home UI, 1 = Level UI, 2 = Game UI
    [SerializeField] GameObject[] popup = new GameObject[4]; // 0 = About, 1 = Quit, 2 = Menu, 3 = Benar
    [SerializeField] GameObject[] toggle = new GameObject[2]; // 0 = SFX, 1 = Music
    [SerializeField] AudioClip[] musicClip = new AudioClip[2]; // 0 = Music Home UI & Level UI, 1 = Music Game UI
    [SerializeField] AudioSource musicSource;
    [SerializeField] Questions Questions;
    [SerializeField] Player Player;
    [SerializeField] GameObject Level;
    public Button[] btnLv;
    public Button resume;

    public void homeUI()
    {
        UI[0].SetActive(true);
        UI[1].SetActive(false);
        UI[2].SetActive(false);
    }

    public void levelUI()
    {
        UI[0].SetActive(false);
        UI[1].SetActive(true);
        UI[2].SetActive(false);
    }

    public void gameUI()
    {
        UI[0].SetActive(false);
        UI[1].SetActive(false);
        UI[2].SetActive(true);
    }

    public void playerData()
    {
        // Load Player Data
        Player.LoadPlayer();
        toggle[0].GetComponent<Toggle>().isOn = Player.sfx;
        toggle[1].GetComponent<Toggle>().isOn = Player.music;
        // Total Level
        int totalLevel = Questions.data.GetLength(0);
        // Lv Terbuka
        int playerlevel = Player.level > totalLevel ? Player.level - 1 : Player.level;
        // Persenan
        double persen = (100 / (totalLevel * 1.0)) * (Player.level - 1);
        // Output di Level UI
        Level.GetComponent<TextMeshProUGUI>().text = "Lv Terbuka: " + playerlevel + " / " + totalLevel + "\n Progress: " + (int)persen + "%";
        // Tombol Resume
        if (Player.level == 1) {
            resume.GetComponentInChildren<TextMeshProUGUI>().text = "Gasskeun!";
        }
        else if (Player.level > totalLevel)
        {
            resume.interactable = false;
            resume.GetComponentInChildren<TextMeshProUGUI>().text = "Tamat!";
        }
        else
        {
            resume.GetComponentInChildren<TextMeshProUGUI>().text = "Lanjutkan!";
        }
        // Tombol Lv
        for (int i = 0; i < btnLv.Length; i++)
        {
            if (i < Player.level)
            {
                btnLv[i].interactable = true;
                btnLv[i].GetComponentInChildren<TextMeshProUGUI>().text = (i+1).ToString();
            }
            else
            {
                btnLv[i].interactable = false;
                btnLv[i].GetComponentInChildren<TextMeshProUGUI>().text = null;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Player Data
        playerData();
        // Buka Home UI
        homeUI();
    }

    // Update is called once per frame
    void Update()
    {
        // Player Data
        playerData();

        // Set Music untuk Home UI & Game UI
        musicSource = musicSource.GetComponent<AudioSource>();
        if (UI[0].activeSelf || UI[1].activeSelf)
        {
            if (musicSource.clip != musicClip[0])
            {
                musicSource.clip = musicClip[0];
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != musicClip[1])
            {
                musicSource.clip = musicClip[1];
                musicSource.Play();
            }
        }

        // Jika diklik Tombol Back yang ada di HP
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UI[0].activeSelf)
            {
                if (popup[0].activeSelf)
                {
                    popup[0].SetActive(false);
                }
                else
                {
                    if (popup[1])
                    {
                        popup[1].SetActive(true);
                    }
                }
            }
            else if (UI[1].activeSelf)
            {
                homeUI();
            }
            else
            {
                if (popup[2].activeSelf)
                {
                    popup[2].SetActive(false);
                }else if(popup[3].activeSelf)
                {
                    Questions.onUserClickNext();
                }
                else {
                    levelUI();
                }
            }
        }
    }

    // on Click Toogle SFX
    public void onUserClickSFX()
    {
        Player.sfx = toggle[0].GetComponent<Toggle>().isOn;
        Player.SavePlayer();
    }

    // on Click Toogle SFX
    public void onUserClickMusic()
    {
        Player.music = toggle[1].GetComponent<Toggle>().isOn;
        Player.SavePlayer();
    }

    // on Click Play
    public void onUserClickLevel()
    {
        levelUI();
    }

    // on Click About
    public void onUserClickAbout()
    {
        popup[0].SetActive(true);
    }

    // on Click Ok (on About Popup)
    public void onUserClickAboutOk()
    {
        popup[0].SetActive(false);
    }

    // on Click Quit
    public void onUserClickQuit()
    {
        popup[1].SetActive(true);
    }

    // on Click Yes/No (on Quit Popup)
    public void onUserClickQuitYesNo(int choice)
    {
        if (choice == 1)
        {
            Application.Quit();
        }
        popup[1].SetActive(false);
    }

    // onUserClickHome
    public void onUserClickHome()
    {
        homeUI();
    }

    public void onUserClickResume()
    {
        Questions.onUserClickPlay(Player.level);
    }

    /*
    // on Click Menu (on Game UI)
    public void onUserClickGameUIMenu()
    {
        popup[2].SetActive(true);
    }

    // on Click Main Menu (on Game UI -> Menu Popup)
    public void onUserClickGameUIMenuMain()
    {
        homeUI();
        popup[2].SetActive(false);
    }

    // on Click OK (on Game UI -> Menu Popup)
    public void onUserClickGameUIMenuOK()
    {
        popup[2].SetActive(false);
    }
    */
}
