using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Questions : MonoBehaviour
{
    [SerializeField] GameObject[] popup = new GameObject[2]; // 0 = Salah, 1 = Benar
    public GameObject[] objek = new GameObject[12]; // 0 = Lv, 1 = Qlue, 2 = Question(IMG), 3 = AnswerText, 4 = TrueAnswer, 5 = TrueAnswer(IMG), 6 = SalahPopup, 7 = SalahTitle, 8 = SalahGambar, 9 = SoalGambar, 10 = Qlue Text, 11 +Coin Text
    [SerializeField] GameObject[] keyboard = new GameObject[16]; // Tombol Keyboard
    public GameObject[] q_btn = new GameObject[2]; // 0 = HS Bantuan, 1 = Buka
    [SerializeField] GameObject anim; // Animasi Keyboard
    [SerializeField] Sprite[] soalnya; // Gambar Soal
    [SerializeField] Sprite[] jawaban; // Gambar Jawaban
    [SerializeField] Sprite[] salah = new Sprite[2]; // Gambar di Popup Salah
    [SerializeField] AudioClip[] sfx = new AudioClip[2]; // Sound Efek Popup Salah
    [SerializeField] int lv; // Deklarasi Variabel Level
    [SerializeField] Main Main; // Main Class
    [SerializeField] Player Player; // Player Class
    [SerializeField] int nq = 0;

    // Data Soal Encrypt
    public string[,] enData = new string[,] { // [JAWABAN, KARAKTER_TAMBAHAN , QLUE]
                                     { "uuG7bzOSwcfRTHVHA2WbMA==", "A5eUyMDzZXk=", "eCoz4wto4o8UnW+xIAsJ1WVtnNl7HdOA" }, // 0,0 - 0,1 - 0,2 (Lv.1)
                                     { "LP2D7yFDzIbXfNIlXlrE/w==", "NW6xyA+nltg=", "eCoz4wto4o8UnW+xIAsJ1WVtnNl7HdOA" }, // 1,0 - 1,1 - 1,2 (Lv.2)
                                     { "9zsp3AkZr/8=", "/G14b5ikWsLuv0rYRuWuOA==", "eCoz4wto4o8UnW+xIAsJ1WVtnNl7HdOA" }, // 2,0 - 2,1 - 2,2 (Lv.3)
                                     { "/46cXdBho+E=", "WdxNe4rXA+kACBas1tSIKA==", "nz/BVExtzJHuHk2Bw6wNUdrPq3i2SARz" }, // 3,0 - 3,1 - 3,2 (Lv.4)
                                     { "XamV8Adb0CE=", "lL9cHN5vfmY5j3ku3MjrSA==", "g+XGHm8TIwqvF//802ubspDosANx/zxPrZTLyEpGCZ0=" }, // 4,0 - 4,1 - 4,2 (Lv.5)
                                     { "0WFadP2EmbY=", "iCmz1ECYTKDXfNIlXlrE/w==", "Uws012vDtRYJdScGz6dQ71CyRz2Bpm4i" }, // 5,0 - 5,1 - 5,2 (Lv.6)
                                   };

    // Decrypt Data Soal 
    public string[,] deData;

    // Data urutan qlue yang di buka
    public int[,] qlue = new int[,]
    {
        {9,4,10,7,5,2,11,8,6,1,3,0,0,0,0,0},
        {6,5,8,1,3,9,4,7,2,0,0,0,0,0,0,0},
        {4,6,1,3,5,2,0,0,0,0,0,0,0,0,0,0},
        {3,5,2,4,1,0,0,0,0,0,0,0,0,0,0,0},
        {6,5,4,2,1,3,0,0,0,0,0,0,0,0,0,0},
        {2,3,1,5,6,7,4,0,0,0,0,0,0,0,0,0}
    };

    // Stack untuk menyimpan data tombol kayboard yang dipencet.
    Stack<int> button = new Stack<int>();

    // Method Untuk Mengacak Data di Array
    static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    // Decrypt Data Soal
    public void dataSoal()
    {
        deData = new string[enData.GetLength(0), enData.GetLength(1)];
        for (int i = 0; i < enData.GetLength(0); i++)
        {
            for (int j = 0; j < enData.GetLength(1); j++)
            {
                deData[i, j] = Helper.Decrypt(enData[i, j]);
            }
        }
    }

    // Baca data Qlue yang dibuka
    void rQlue()
    {
        string[] arr = Player.qlue.Split(',');
        nq = int.Parse(arr[lv-1]);
    }

    // Tambah data Qlue yang dibuka
    void wQlue()
    {
        string[] arr = Player.qlue.Split(',');
        string num = null;

        for (int i = 0; i < arr.Length; i++)
        {
            if (i + 1 == lv)
            {
                num += (int.Parse(arr[i])+1).ToString();
            }
            else
            {
                num += int.Parse(arr[i]).ToString();
            }

            if (i + 1 != arr.Length)
            {
                num += ",";
            }
        }
        Player.qlue = num;
    }

    // Set Qlue (Bantuan)
    public void setQlue()
    {
        rQlue();

        string q_st = deData[lv - 1, 0];
        char[] q_ch = new char[q_st.Length];

        for (int i = 0; i < q_st.Length; i++)
        {
            q_ch[i] = q_st[i];
        }

        string[] v_ch = new string[q_st.Length];

        for (int i = 0; i < nq; i++)
        {
            string chrs = q_ch[qlue[lv - 1, i] - 1].ToString();

            for (int j = 0; j < q_ch.Length; j++)
            {
                if (j == qlue[lv - 1, i] - 1)
                {
                    v_ch[j] = chrs;
                }
                else if (v_ch[j] == null || v_ch[j] == "_")
                {
                    v_ch[j] = "_";
                }
            }
        }

        string qlue_text = null;

        for (int i = 0; i < v_ch.Length; i++)
        {
            qlue_text += v_ch[i];
            if (i != v_ch.Length - 1)
            {
                qlue_text += " ";
            }
        }

        objek[10].GetComponent<TextMeshProUGUI>().text = qlue_text;
    }

    // Enabled or Disabled Button Tamoilkan / Sembunyikan Bantuan
    public void interaksiHSBtn()
    {
        if (nq == 0)
        {
            q_btn[0].GetComponent<Button>().interactable = false;
        }
        else
        {
            q_btn[0].GetComponent<Button>().interactable = true;
        }
    }

    // Enabled or Disabled Button Buka
    public void interaksiBukaBtn()
    {
        if (nq == deData[lv - 1, 0].Length || Player.coin < 10)
        {
            q_btn[1].GetComponent<Button>().interactable = false;
        }
        else
        {
            q_btn[1].GetComponent<Button>().interactable = true;
        }
    }

    // Aksi Klik Tombol Play/Level tertetu (x=level) & Merupakan aksi pertama ketika masuk Game UI
    public void onUserClickPlay(int x)
    {
        // Aktifkan Game UI
        Main.gameUI();
        // Matikan Popup Salah
        popup[0].SetActive(false);
        // Matikan Popup Benar
        popup[1].SetActive(false);

        // Hapus Aktifitas Sebelumnya
        objek[3].GetComponent<TextMeshProUGUI>().text = ""; // Hapus Teks Answer
        button.Clear(); // Hapus Data didalam Stack

        // Play Animasi Keyboard
        anim.GetComponent<Animator>().Play(0);

        // Set Level
        lv = x; // Dimulai dari 1 bukan 0
        // Set Object Lv
        objek[0].GetComponent<TextMeshProUGUI>().text = "Lv."+lv;
        // Set Object Qlue
        objek[1].GetComponent<TextMeshProUGUI>().text = deData[lv - 1, 2];
        // Set Object Questions
        objek[2].GetComponent<Image>().sprite = soalnya[lv-1];

        // Matikan Teks Qlue
        setQlue();
        objek[10].SetActive(false);

        // Split String ke Char
        string st = deData[lv - 1, 0] + deData[lv - 1, 1];
        char[] ch = new char[st.Length];

        for (int i = 0; i < st.Length; i++)
        {
            ch[i] = st[i];
        }

        // Acak Keyboard
        ShuffleArray(ch);

        for (int i = 0; i < ch.Length; i++)
        {
            keyboard[i].GetComponentInChildren<TextMeshProUGUI>().text = ch[i].ToString();
            keyboard[i].SetActive(true);
        }
    }

    // Klik Tombol Buka
    public void onUserClickBuka()
    {
        if (nq < deData[lv - 1, 0].Length && Player.coin-10 >= 0)
        {
            // Kurangi Coin
            Player.coin = Player.coin - 10;
            // Buka Qlue
            wQlue();
        }
        setQlue();
        objek[10].SetActive(true);
        objek[10].GetComponent<AudioSource>().Play();
        Main.onUserClickQlueClose();
    }

    // Tombol Hide & Show Qlue
    public void onUserClickHS()
    {
        if (objek[10].activeSelf == true)
        {
            objek[10].SetActive(false);
            q_btn[0].GetComponentInChildren<Text>().text = "Tampilkan Bantuan";
        }
        else
        {
            objek[10].SetActive(true);
            q_btn[0].GetComponentInChildren<Text>().text = "Sembunyikan Bantuan";
        }
        Main.onUserClickQlueClose();
    }

    // Simpan Nomor/ID Tombol yang dipencet kedalam Stack & Nonaktifkan Tombol Tersebut
    public void onUserClickChar(int x)
    {
        button.Push(x); // Simpan di stack
        objek[3].GetComponent<TextMeshProUGUI>().text += keyboard[x].GetComponentInChildren<TextMeshProUGUI>().text; // Masukan Karakter ke Teks Jawaban
        keyboard[x].SetActive(false); // Hide Tombol
    }

    // Aksi Tombol Hapus
    public void onUserClickRemove()
    {
        int txtlength = objek[3].GetComponent<TextMeshProUGUI>().text.Length;
        if (txtlength != 0)
        {
            objek[3].GetComponent<TextMeshProUGUI>().text = objek[3].GetComponent<TextMeshProUGUI>().text.Remove(txtlength - 1); // Hapus Teks Terakhir
            int x = button.Peek(); // Data Nomor/ID Keyboard yg Terakhir Masuk

            // Aktifkan (Unhide) tombol yang Terakhir dipencet
            for (int i = 0; i < keyboard.Length; i++)
            {
                if (x == i)
                {
                    keyboard[i].SetActive(true);
                }
            }

            button.Pop(); // Hapus Data Nomor/ID Keyboard yg Terakhir dari Stack
        }
    }

    // Aksi tombol Pancal
    public void onUserClickPancal()
    {
        int txtlength = objek[3].GetComponent<TextMeshProUGUI>().text.Length;
        if (txtlength != 0) {
            string answer = deData[lv - 1, 0];
            if (objek[3].GetComponent<TextMeshProUGUI>().text == answer)
            {
                // Simpan Progress Level
                if (Player.level == lv)
                {
                    Player.level = lv+1;
                    Player.coin += 50;
                    objek[11].GetComponent<Text>().text = "+50";
                    // Karena sudah dipasang di Update(), jadi script dibawah ga perlu dipasang disini lagi, jadi saya matikan yg disini
                    // Player.SavePlayer();
                }
                else
                {
                    objek[11].GetComponent<Text>().text = "+0";
                }

                objek[4].GetComponent<Text>().text = answer;
                objek[5].GetComponent<Image>().sprite = jawaban[lv - 1];
                objek[9].GetComponent<Image>().sprite = soalnya[lv - 1];
                popup[1].SetActive(true);
            }
            else
            {
                popup[0].SetActive(false);
                int rd = Random.Range(0, 100); // Acak Bacotan
                if (rd >= 50)
                {
                    // Bacot Dedy Corbuzier
                    objek[6].GetComponent<AudioSource>().clip = sfx[1];
                    objek[7].GetComponent<Text>().text = "TOLOL!";
                    objek[8].GetComponent<Image>().sprite = salah[1];
                }
                else
                {
                    // Bacot Yudha Keling
                    objek[6].GetComponent<AudioSource>().clip = sfx[0];
                    objek[7].GetComponent<Text>().text = "GOBLOK!";
                    objek[8].GetComponent<Image>().sprite = salah[0];
                } 
                popup[0].SetActive(true);
            }
        } 
    }

    // Aksi Klik Tombol Next di Popup Benar
    public void onUserClickNext()
    {
        if(deData.GetLength(0) != lv)
        {
            onUserClickPlay(lv+1); // Buka soal (level) berikutnya
        }
        else
        {
            Main.levelUI(); // Lempar ke Level UI jika Level Tercapai sudah Max.
        }
    }
}

/**
 * Game ini dibuat menggunakan Unity 2019.4 Personal
 * Programmer: Bagus Pangestu
 * Contact: baguspangestu@yandex.com
 * Project: https://github.com/baguspangestu/kbb
*/