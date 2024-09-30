using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;

    [Header("Elements")]
    [SerializeField] private CanvasGroup gameCG;
    [SerializeField] private CanvasGroup levelCompleteCG;

    private void Awake()
    {
        if(instance == null)
        instance = this;
        else
        Destroy(gameObject);
    }

    void Start()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }


    private void GameStateChangedCallback(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.LevelComplete:
                ShowLevelComplete();
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
        ShowCG(gameCG);
    }

    private void HideGame()
    {
        HideCG(gameCG);
    }

    private void ShowLevelComplete()
    {
        ShowCG(levelCompleteCG);
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
