using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{

    [Header("Elements ")]
    [SerializeField] private GameObject keyboard;
    private KeyboardKey[] keys;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        keys = keyboard.GetComponentsInChildren<KeyboardKey>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KeyboardHint()
    {
        string secretword = WordManager.instance.GetSecretWord();
        List<KeyboardKey> untouchedKeys = new List<KeyboardKey>();
    }

    public void LetterHint()
    {
        
    }
}
