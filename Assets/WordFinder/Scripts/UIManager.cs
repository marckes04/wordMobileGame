using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;

    [Header("Elements")]
    [SerializeField] private CanvasGroup gameCG;
    [SerializeField] private CanvasGroup levelCompleteCG;
    [SerializeField] private CanvasGroup gameoverCG;

    [Header("Level Complete Elements")]
    [SerializeField] private TextMeshProUGUI levelCompleteCoins;
    [SerializeField] private TextMeshProUGUI levelCompleteSecretWord;
    [SerializeField] private TextMeshProUGUI levelCompleteScore;
    [SerializeField] private TextMeshProUGUI levelCompleteBestScore;


    [Header("Game Elements")]
    [SerializeField] private TextMeshProUGUI gameScore;
    [SerializeField] private TextMeshProUGUI gameCoins;


    [Header("Gameover Elements")]
    [SerializeField] private TextMeshProUGUI gameOverCoins;
    [SerializeField] private TextMeshProUGUI gameOverSecretWord;
    [SerializeField] private TextMeshProUGUI gameOverBestScore;

    private void Awake()
    {
        if(instance == null)
        instance = this;
        else
        Destroy(gameObject);
    }

    void Start()
    {
        ShowGame();
        HideLevelComplete();
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }


    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
                ShowGame();
                HideLevelComplete();
                HideGameover();
                break;

            case GameState.LevelComplete:
                ShowLevelComplete();
                HideGame();
                break;
            case GameState.GameOver:
                ShowGameover();
                HideGame();
                break;
        }
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void ShowGame()
    {
        gameCoins.text = DataManager.instance.GetCoins().ToString();
        gameScore.text = DataManager.instance.GetScore().ToString();


        ShowCG(gameCG);
    }

    private void HideGame()
    {
        HideCG(gameCG);
    }

    private void ShowLevelComplete()
    {
        levelCompleteCoins.text = DataManager.instance.GetCoins().ToString();
        levelCompleteSecretWord.text = WordManager.instance.GetSecretWord();
        levelCompleteScore.text = DataManager.instance.GetScore().ToString();
        levelCompleteBestScore.text = DataManager.instance.GetBestScore().ToString();

        ShowCG(levelCompleteCG);
    }

    private void ShowGameover()
    {
        gameOverCoins.text = DataManager.instance.GetCoins().ToString();
        gameOverSecretWord.text = WordManager.instance.GetSecretWord();
        gameOverBestScore.text = DataManager.instance.GetBestScore().ToString();

        ShowCG(gameoverCG);
    }

    private void HideGameover()
    {
        HideCG(gameoverCG);
    }

    private void HideLevelComplete()
    {
        HideCG(levelCompleteCG);
    }

    private void ShowCG(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    private void HideCG(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }
}
