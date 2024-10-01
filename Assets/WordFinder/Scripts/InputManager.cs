using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private WordContainer[] wordContainers;
    [SerializeField] private Button tryButton;
    [SerializeField] private KeyboardColorizer keyboardColorizer;


    [Header("settings")]
    private int currentWordContainerIndex;

    private bool canAddLetter = true;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        KeyboardKey.onKeyPressed += KeyPressedCallback;
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }


    private void OnDestroy()
    {
        KeyboardKey.onKeyPressed -= KeyPressedCallback;
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Game:
               Initialize();
                break;

            case GameState.LevelComplete:
               
                break;
        }

    }

    private void Initialize()
    {
        currentWordContainerIndex = 0;
        canAddLetter = true;

        DisableTryButton();

        for (int i = 0; i < wordContainers.Length; i++) 
        {
            wordContainers[i].Initialize();
        }
    }

    


    private void KeyPressedCallback(char letter)
    {


        if (!canAddLetter) 
            return;
        


        wordContainers[currentWordContainerIndex].Add(letter);
        if (wordContainers[currentWordContainerIndex].IsComplete())
        {
           canAddLetter = false;
           EnableTryButton();
        }
    }

    public void checkWord()
    {
        string wordToCheck = wordContainers[currentWordContainerIndex].GetWord();
        string secretWord = WordManager.instance.GetSecretWord();

        wordContainers[currentWordContainerIndex].Colorize(secretWord);
        keyboardColorizer.Colorize(secretWord, wordToCheck); 

        if (secretWord == wordToCheck)
        {
            SetLevelComplete();
        }
        else
        {
           // Debug.Log("Wrong word");
            currentWordContainerIndex++;
            DisableTryButton();

            if (currentWordContainerIndex >= wordContainers.Length) 
            {
                DataManager.instance.ResetScore();
                GameManager.instance.SetGameState(GameState.GameOver);
            }
            else
            {
                canAddLetter = true;
            }
        }
    }

    private void SetLevelComplete()
    {
        UpdateData();
        GameManager.instance.SetGameState(GameState.LevelComplete);
    }

    private void UpdateData()
    {
        int scoreToAdd = 6 - currentWordContainerIndex;

        DataManager.instance.IncreaseScore(scoreToAdd);
        DataManager.instance.AddCoins(scoreToAdd * 3);
    }

    public void BackspacePressedCallBack()
    {
        if (GameManager.instance.IsGameState()) ;

       bool removeLetter =  wordContainers[currentWordContainerIndex].RemoveLetter();

        if (removeLetter)
            DisableTryButton();

        canAddLetter = true;
    }

    private void EnableTryButton()
    {
        tryButton.interactable = true;
    }

    private void DisableTryButton()
    {
        tryButton.interactable = false;
    }

}
