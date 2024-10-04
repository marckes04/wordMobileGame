using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i].IsUntouched())
                untouchedKeys.Add(keys[i]);
        }
        // At this point we have a list of all the untouched keys
        List<KeyboardKey> t_untouchedKeys = new List<KeyboardKey>(untouchedKeys);
        for (int i = 0; i < untouchedKeys.Count; i++)
        {
            if (secretword.Contains(untouchedKeys[i].GetLetter()))
                t_untouchedKeys.Remove(untouchedKeys[i]);
        }

        // We have all keys

        if (t_untouchedKeys.Count <= 0)
            return;

        int randomKeyIndex = Random.Range(0, t_untouchedKeys.Count);
        t_untouchedKeys[randomKeyIndex].SetInvalid();
    }

    public void LetterHint()
    {
       
    }
}
