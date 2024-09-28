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
    }

    private void Initialize()
    {
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


            // checkWord();
            //currentWordContainer++;
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
            Debug.Log("Level complete");
        }
        else
        {
            Debug.Log("Wrong word");

            canAddLetter = true;
            DisableTryButton();
            currentWordContainerIndex++;
        }
           
    }

    public void BackspacePressedCallBack()
    {
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
