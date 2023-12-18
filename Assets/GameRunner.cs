using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    [SerializeField] GameObject Bric1;
    [SerializeField] GameObject Bric2;
    [SerializeField] public RectTransform STRTextT;
    [SerializeField] public TextMeshProUGUI TMP;
    public int Wins = 0;
    public int BricksLeft = 35;
    public int Score = 0;
    public bool RestartPrimed = false;
    // Start is called before the first frame update
    void Start()
    {
        TMP.text = Score.ToString();
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (BricksLeft == 0)
        {
            RestartPrimed = true;
        }
    }

    public void MoveUpText()
    {
        STRTextT.anchoredPosition = new Vector2(0,5);
    }
    public void ResetBall()
    {
        Score -= 500;
        TMP.text = Score.ToString();
        STRTextT.anchoredPosition = new Vector2(0, -50);
    }
    public void BreakBrick()
    {
        BricksLeft--;
        Score += 100;
        TMP.text = Score.ToString();
    }

    public void SetUpBoard()
    {
        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 7; j++)
            {
                if ((i + j) % 2 == 1)
                {
                    Instantiate(Bric1, new Vector3(j - 4, 0.5f * i + 5.25f, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(Bric2, new Vector3(j - 4, 0.5f * i + 5.25f, 0), Quaternion.identity);
                }
            }
        }
    }
    public void StartGame()
    {
        BricksLeft = 35;
        SetUpBoard();
    }
}
