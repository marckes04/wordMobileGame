using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private WordContainer[] wordContainers;


    [Header("settings")]
    private int currentWordContainer;


    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        KeyboardKey.onKeyPressed += KeyPressedCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (wordContainers[currentWordContainer].IsComplete())
            currentWordContainer++;

        wordContainers[currentWordContainer].Add(letter);
    }

}
