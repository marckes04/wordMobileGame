using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyboardKey : MonoBehaviour
{

    [Header("Elements ")]
    [SerializeField] private TextMeshProUGUI letterText;
    // Start is called before the first frame update

    [Header("Events")]
    public static Action<char> onKeyPressed;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendKeyPress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SendKeyPress()
    {
        onKeyPressed?.Invoke(letterText.text[0]);
    }
}
