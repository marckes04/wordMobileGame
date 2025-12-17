using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    [Header(" sounds ")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource letterAddedSound;
    [SerializeField] private AudioSource letterRemoveSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameoverSound;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        InputManager.onLetterAdded += PlayLetterAddedSound;
        InputManager.onLetterRemoved += PlayLetterRemovedSound;

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onLetterAdded -= PlayLetterAddedSound;
        InputManager.onLetterRemoved -= PlayLetterRemovedSound;

        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }

    private void GameStateChangedCallback(GameState gameState) 
    {
        switch (gameState)
        {
            case GameState.LevelComplete:
                levelCompleteSound.Play();
                break;
            case GameState.GameOver:
                gameoverSound.Play();
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayLetterAddedSound()
    {
        letterAddedSound.Play();
    }

    private void PlayLetterRemovedSound()
    {
        letterRemoveSound.Play();
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    public void EnableSounds()
    {
        buttonSound.volume = 1;
        letterAddedSound.volume = 1;
        letterRemoveSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameoverSound.volume = 1;

    }

    public void DisableSounds() 
    {
        buttonSound.volume = 0;
        letterAddedSound.volume = 0;
        letterRemoveSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameoverSound.volume = 0;
    }
}
