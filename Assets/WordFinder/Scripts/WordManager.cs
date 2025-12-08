using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
public static WordManager instance;

    [Header("Elements")]
    [SerializeField] private string secretword;
    [SerializeField] private TextAsset wordsText;
    private string words;

    private void Awake()
    {
        if (instance == null)
        
            instance = this;
        else
            Destroy(gameObject);
        
        words = wordsText.text;
    }

    void Start()
    {
      SetNewSecretWord();    
    }

    public string GetSecretWord() 
    { 
        return secretword.ToUpper();
    }

    private void SetNewSecretWord()
    {
        Debug.Log("String length : " +  words.Length);
        int wordCount = (words.Length + 2) / 7;

        int wordIndex = Random.Range(0, wordCount);

        int wordStartIndex = wordIndex * 7;

        secretword = words.Substring(wordStartIndex, 5).ToUpper();
    }

}
