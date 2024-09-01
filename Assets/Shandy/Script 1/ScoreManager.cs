using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    public TextMeshProUGUI uang;
    public TextMeshProUGUI poin;
    int score = 50000;
    int poinluti = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        uang.text = "Rp."+ score.ToString();
        poin.text = "Luti:0" + poinluti.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Tambahkan logika untuk memperbarui skor di sini jika diperlukan
    }

    // Fungsi untuk menambah skor dan memperbarui teks
    public void kurangScore()
    {
        score -= 2000;
        uang.text = "Rp." + score.ToString();
    }

    public void kurang1Score()
    {
        score -= 3000;
        uang.text = "Rp." + score.ToString();
    }
    public void kurang2Score()
    {
        score -= 3000;
        uang.text = "Rp." + score.ToString();
    }
    public void Tambahpoin()
    {
        poinluti += 1 ;
        poin.text = "Luti:" + poinluti.ToString();
    }
}

