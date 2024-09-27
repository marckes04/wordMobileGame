using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterContainer : MonoBehaviour
{

    [Header(" Elements")]
    [SerializeField] private TextMeshPro letter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        letter.text = "";
    }

    public void SetLetter(char letter)
    {
        this.letter.text = letter.ToString();
    }
}
