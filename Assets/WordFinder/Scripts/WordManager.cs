using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
public static WordManager instance;

    [Header("Elements")]
    [SerializeField] private string secretword;

    private void Awake()
    {
        if (instance == null)
        
            instance = this;
        else
            Destroy(gameObject);
        
    }


    public string GetSecretWord() 
    { 
        return secretword.ToUpper();
    }

}
