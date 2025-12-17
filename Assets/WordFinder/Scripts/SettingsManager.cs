using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image soundsImage;
    [SerializeField] private Image hapticsImage; // Correctly references the haptics image

    [Header(" Settings ")]
    private bool soundState;
    private bool hapticsState;

    // Start is called before the first frame update
    void Start()
    {
        LoadStates();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SoundsButtonCallback()
    {
        soundState = !soundState;
        UpdateSoundsState();
        SaveStates();
    }

    private void UpdateSoundsState()
    {
        if (soundState)
            EnableSounds();
        else
            DisableSounds();
    }

    private void EnableSounds()
    {
        SoundsManager.instance.EnableSounds();
        soundsImage.color = Color.white;
    }

    private void DisableSounds()
    {
        SoundsManager.instance.DisableSounds();
        soundsImage.color = Color.gray;
    }


    public void HapticsButtonCallback()
    {
        hapticsState = !hapticsState;
        UpdateHapticsState();
        SaveStates();
    }

    private void UpdateHapticsState()
    {
        // **CORRECTION 1:** Check 'hapticsState' here, not 'soundState'
        if (hapticsState)
            EnableHaptics();
        else
            DisableHaptics();
    }

    private void EnableHaptics()
    {
        //HapticsManager.instance.EnableHaptics(); // Adjusted comment to HapticsManager and Haptics
        // **CORRECTION 2:** Use 'hapticsImage' and set color to white for enabled
        hapticsImage.color = Color.white;
    }

    private void DisableHaptics()
    {
        //HapticsManager.instance.DisableHaptics(); // Adjusted comment to HapticsManager and Haptics
        // **CORRECTION 3:** Use 'hapticsImage' and set color to gray for disabled
        hapticsImage.color = Color.gray;
    }

    private void LoadStates()
    {
        soundState = PlayerPrefs.GetInt("sounds", 1) == 1;
        hapticsState = PlayerPrefs.GetInt("haptics", 1) == 1;

        UpdateSoundsState();
        UpdateHapticsState();
    }

    private void SaveStates()
    {
        PlayerPrefs.SetInt("sounds", soundState ? 1 : 0);
        PlayerPrefs.SetInt("haptics", hapticsState ? 1 : 0);
    }
}
