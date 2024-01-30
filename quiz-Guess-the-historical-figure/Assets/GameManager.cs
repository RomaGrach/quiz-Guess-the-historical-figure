
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using YG;

public class GameManager : MonoBehaviour
{
    
    public GameObject CanvasStartMenue;
    public GameObject CanvasGame;
    public GameObject CanvasInterestingFact;
    public GameObject CanvasProgress;
    public GameObject CanvasEND;
    public GameObject CanvasTransitionAnimation;
    public GameObject FinalTextRightAns;
    public GameObject FinalTextRongAns;
    public GameObject CanvasBock;
    [SerializeField] TextMeshProUGUI TextQquestion;
    [SerializeField] TextMeshProUGUI TextLevel;
    [SerializeField] TextMeshProUGUI TextFinalScore;
    [SerializeField] TextMeshProUGUI TextScore;
    [SerializeField] TextMeshProUGUI TextStartScore;
    [SerializeField] TextMeshProUGUI TextInterestingFact;
    [SerializeField] TextMeshProUGUI TextRightAns;
    [SerializeField] Image ImageCanvasGame;
    [SerializeField] Image ImageCanvasInterestingFact;
    [SerializeField] Image ImageCanvasEND;
    [SerializeField] Image ImageProgres;

    [SerializeField] TextMeshProUGUI[] TextButton;
    [SerializeField] Image ImageTank;

    public Sprite[] TankPictures;

    public Sprite[] BackgroundPicturesWin;

    /*
    public string[,] ansvers = new string[,]
    {
        {"101110001011010100110110001001", },// "101010101010101010101010101010", "111000111000111000111000111000", "110110110110110110110110110110"},
        {"010101010101010101010101010101", },//"001100110011001100110011001100", "000111000111000111000111000111","011001110110011001100101010010"},
        {"100100100100100100100100100100", },//"101010101010101010101010101010", "110011001100110011001100110011","100110101001100101011010100011"},
        {"011001100110011001100110011001", },//"010101010101010101010101010101", "001111000111100011110001111000","010100001101101010010100001101"},
        {"111100001111000011110000111100", },//"110011001100110011001100110011", "101010101010101010101010101010","100101100101100100010011010110"},
        {"000011110000111100001111000011", },//"001100110011001100110011001100", "010101010101010101010101010101","011000001010010110100110010100"},
        {"110011001100110011001100110011", },//"101010101010101010101010101010", "111000111000111000111000111000","101110001001010100110110001001"},
        {"100010001000100010001000100010", },//"110011001100110011001100110011", "111111000000111111000000111111","100101100001100100010011010110"},
        {"011110000111100001111000011110", },//"010101010101010101010101010101", "001111111100000011111111000000","010100001101001010010100001101"},
    };
    */
    string[] TanksName = new string[]
    {
        "МиГ-29СМТ",
        "Су-27",
        "Як-141",
        "МиГ-29",
        "МиГ-23МЛД",
        "МиГ-23М",
        "Су-17М4",
        "МиГ-21СМТ",
        "МиГ-21бис",
        "Су-17М2",
        "Су-25Т",
        "МиГ-27М",
        "МиГ-27К",
        "Су-22М3",
        "МиГ-23МЛ",
        "Су-39",
        "Су-25БМ",
        "F-16C",
        "F-16A",
        "F-16A ADF",
        "F-15A",
        "F-14B",
        "F-14A Early",
        "F-5E",
        "F-4C Phantom II",
        "F-4E Phantom II",
        "F-8E",
        "F-4J Phantom II",
        "A-10A Late",
        "A-7D",
        "A-7E",
        "F-105D",
        "F-111A",
        "F-4S Phantom II",
        "A-6E TRAM",
        "F-5C",
        "A-7K",
        "F-5A",
        "JAS39C",
        "Tornado F.3",
        "Harrier GR.7",
        "Tornado GR.1",
        "Sea Harrier FRS.1 (e)",
        "Jaguar GR.1A",
        "J-11",
        "J-8F",
        "JH-7A",
        "Q-5L",
        "F-104S",
        "AMX",
        "Mirage 2000-5F",
        "Mirage 4000",
        "Mirage F1C",
        "Mirage IIIC",
        "F-8E(FN)",
        "Mirage F1CT",
        "Super Etendard",
        "Jaguar A",
        "Saab J35XS",
        "JA37D",
        "JA37C",
        "J35D",
        "AJS37",
    };

    

    public int Level = 0;
    public int Score = 0;
    public List<int> GetTank = new List<int>() {};
    public int TankNow = 0;
    public int FinalScore = 0;
    public int ansButton;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        YandexGame.OpenFullAdEvent += StopGame;
        YandexGame.CloseFullAdEvent += PlayGame;
        YandexGame.OpenVideoEvent += StopGame;
        YandexGame.CloseVideoEvent += PlayGame;
        YandexGame.RewardVideoEvent += Reward;
        YandexGame.FullscreenShow();
        CanvasStartMenue.SetActive(true);
        CanvasGame.SetActive(false);
        CanvasInterestingFact.SetActive(false);
        CanvasProgress.SetActive(false);
        CanvasEND.SetActive(false);
        CanvasTransitionAnimation.SetActive(false);
        FinalTextRightAns.SetActive(false);
        Level = 0;
        Score = 0;
        TextStartScore.text = YandexGame.savesData.MaxScore.ToString();
    }
    public void PresAddButton()
    {
        YandexGame.RewVideoShow(1);

    }

    void Reward(int id)
    {
        if (id==1)
        {
            TextButton[ansButton].color = new Color(0, 256, 0, 256);
        }

    }

    void StopGame()
    {
        Time.timeScale = 0f;
        AudioListener.volume = 0f;
    }

    void PlayGame()
    {
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
    }


    private void Update()
    {
        TextStartScore.text = YandexGame.savesData.MaxScore.ToString();
    }

    public void IfTheGameStartButtonIsPressed()
    {
        GetTank = new List<int>() { };
        Level = 0;
        Score = 0;
        StartCoroutine(PlayAnimation());
        StartCoroutine(TimerForGameMenu());
        StartCoroutine(TimerToChangeQuestion());
        FinalTextRightAns.SetActive(false);
        FinalTextRongAns.SetActive(false);
    }

    /*

    public void IfTheButtonIsPressedFurtherInTheMenuInterestingFact()
    {
        StartCoroutine(PlayAnimation());
        StartCoroutine(TimerForGameMenu());
        StartCoroutine(TimerToChangeQuestion());
    }
    */
    public void IfTheButtonIsPressedAgainInTheFinalMenu()
    {
        YandexGame.FullscreenShow();
        StartCoroutine(PlayAnimation());
        StartCoroutine(TimerForStartMenu());
        Level = 0;
        Score = 0;
    }

    public void IfTheAnswerButtonIsPressedInTheGameMenu(int ans)
    {
        //TextButton[ansButton].faceColor = new Color(0, 256, 0, 256);
        if (ans == ansButton)
        {
            float koef = Time.time - startTime;
            Debug.Log(koef);
            if (koef < 1f)
            {
                Score += 6;
            }
            if (koef < 5f)
            {
                Score += 5;
            }
            else if (koef < 10f)
            {
                Score += 4;
            }
            else if (koef < 20f)
            {
                Score += 3;
            }
            else if (koef < 30f)
            {
                Score += 2;
            }
            else
            {
                Score += 1;
            }

            if (Score > YandexGame.savesData.MaxScore)
            {
                YandexGame.savesData.MaxScore = Score;
                YandexGame.SaveProgress();
                YandexGame.NewLeaderboardScores("Score", YandexGame.savesData.MaxScore);
                TextStartScore.text = YandexGame.savesData.MaxScore.ToString();
            }

            if ((GetTank.Count + 4) >= (float)TankPictures.Length)
            {
                FinalTextRightAns.SetActive(true);
                FinalTextRongAns.SetActive(false);
                EnableEndMenu();
            }
            else
            {
                StartCoroutine(PlayAnimation());
                StartCoroutine(TimerToChangeQuestion());
            }
        }
        else
        {
            //TextButton[ansButton].faceColor = new Color(0, 256, 0, 256);
            StartCoroutine(RongAns());
        }

        

    }

    void EnableEndMenu()
    {
        //ChooseClosestBird();
        //TextButton[ansButton].faceColor = new Color(50, 50, 50, 256);
        StartCoroutine(PlayAnimation());
        StartCoroutine(TimerForEndMenu());

    }
    /*
    private void ChooseClosestBird()
    {
        int minDifference = int.MaxValue;
        int birdsCount = ansvers.GetLength(0);
        int answersLength = ansvers.GetLength(1);

        for (int i = 0; i < FinalComments.GetLength(0); i++)
        {
            int differences = 0;
            for (int j = 0; j < answersLength; j++)
            {
                for (int k = 0; k < ansver.Length; k++) {
                    if (ansvers[i, j][k] != ansver[k])
                    {
                        differences++;
                    }
                }
                if (differences < minDifference)
                {
                    minDifference = differences;
                    closestBird = i; // Пример, замените на вашу систему идентификации птиц
                }
            }
            Debug.Log((minDifference, differences, closestBird, i));
        }

    }
    */

    /*
    void EnableInterestingFactsMenu()
    {
        StartCoroutine(PlayAnimation());
        StartCoroutine(TimerForInterestingFacts());
        TextInterestingFact.text = InterestingFacts[Random.Range(0, InterestingFacts.Length)];
        ImageCanvasInterestingFact.sprite = BackgroundPictures[Random.Range(0, BackgroundPictures.Length)];

    }
    */
    private IEnumerator PlayAnimation()
    {
        CanvasTransitionAnimation.SetActive(true);
        yield return new WaitForSeconds(1f);
        CanvasTransitionAnimation.SetActive(false);
    }

    private IEnumerator RongAns()
    {
        CanvasBock.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            if (i == ansButton)
            {
                TextButton[i].color = new Color(0, 256, 0, 256);
            }
            else
            {
                TextButton[i].color = new Color(256, 0, 0, 256);
            }
        }
        yield return new WaitForSeconds(1.5f);
        CanvasBock.SetActive(false);
        for (int i = 0; i < 4; i++)
        {
            TextButton[i].color = new Color(0, 0, 0, 255);
        }
        FinalTextRightAns.SetActive(false);
        FinalTextRongAns.SetActive(true);
        EnableEndMenu();
    }

    /*

    private IEnumerator TimerForInterestingFacts()
    {
        yield return new WaitForSeconds(0.5f);
        CanvasStartMenue.SetActive(false);
        CanvasGame.SetActive(false);
        CanvasInterestingFact.SetActive(true);
        CanvasProgress.SetActive(false);
        CanvasEND.SetActive(false);
    }

    */
    private IEnumerator TimerForGameMenu()
    {
        yield return new WaitForSeconds(0.5f);
        CanvasStartMenue.SetActive(false);
        CanvasGame.SetActive(true);
        CanvasInterestingFact.SetActive(false);
        CanvasProgress.SetActive(true);
        CanvasEND.SetActive(false);
    }

    private IEnumerator TimerToChangeQuestion()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 4; i++)
        {
            TextButton[i].color = new Color(0, 0, 0, 256);
        }

        //TextQquestion.text = questions[ansver.Length];
        //TextLevel.text = ansver.Length.ToString();
        TextScore.text = Score.ToString();
        startTime = Time.time;
        bool f = true;
        while (f)
        {
            TankNow = UnityEngine.Random.Range(0, TankPictures.Length);
            if (!GetTank.Contains(TankNow))
            {
                GetTank.Add(TankNow);
                f = false;
            }
        }
        ansButton = UnityEngine.Random.Range(0, 4);
        List<int> LosAns = new List<int>() { };
        while (LosAns.Count<4)
        {
            f = true;
            while (f)
            {
                int Los = UnityEngine.Random.Range(0, TankPictures.Length);
                if (!GetTank.Contains(Los))
                {
                    LosAns.Add(Los);
                    f = false;
                }
            }
        }
        LosAns[ansButton] = TankNow;
        for (int i = 0; i <4; i++)
        {
            TextButton[i].text = TanksName[LosAns[i]];
        }
        ImageTank.sprite = TankPictures[TankNow];
        TextLevel.text = GetTank.Count.ToString();
        ImageProgres.fillAmount = Mathf.Clamp01((float)GetTank.Count / ((float)TankPictures.Length-4));
    }

    private IEnumerator TimerForEndMenu()
    {
        yield return new WaitForSeconds(0.5f);
        CanvasStartMenue.SetActive(false);
        CanvasGame.SetActive(false);
        CanvasInterestingFact.SetActive(false);
        CanvasProgress.SetActive(false);
        CanvasEND.SetActive(true);
        TextFinalScore.text = Score.ToString();
        TextRightAns.text = TanksName[TankNow];
        //ImageCanvasEND.sprite = BackgroundPicturesWin[closestBird];
    }

    private IEnumerator TimerForStartMenu()
    {
        yield return new WaitForSeconds(0.5f);
        CanvasStartMenue.SetActive(true);
        CanvasGame.SetActive(false);
        CanvasInterestingFact.SetActive(false);
        CanvasProgress.SetActive(false);
        CanvasEND.SetActive(false);


    }
}
