using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UI module for Toggle and Scrollbar

public class AudioAdjust : MonoBehaviour
{
    private Toggle toggle;
    private Scrollbar scrollbar;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Toggle component
        toggle = GetComponent<Toggle>();

        // Get the Scrollbar component
        scrollbar = GetComponent<Scrollbar>();

        // Set the initial audio state and volume
        SetAudioState();
        SetVolume();
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other logic here if needed
    }

    // This method is called when the toggle is switched
    public void OnToggleSwitch()
    {
        // Toggle the audio state
        ToggleAudioState();
    }

    // This method is called when the scrollbar value changes
    public void OnVolumeChange()
    {
        // Adjust the volume based on the scrollbar value
        AdjustVolume();
    }

    // Toggle the audio state (mute/unmute)
    void ToggleAudioState()
    {
        // Invert the current audio state
        AudioListener.pause = !AudioListener.pause;

        // Set the toggle's state to match the audio state
        if (toggle != null)
        {
            toggle.isOn = !AudioListener.pause;
        }
    }

    // Adjust the volume based on the scrollbar value
    void AdjustVolume()
    {
        // Invert the scrollbar value to have max volume on the right
        float invertedValue = 1.0f - scrollbar.value;

        // Set the audio volume based on the inverted scrollbar value
        AudioListener.volume = invertedValue;
    }

    // Set the initial audio state and volume based on the current toggle and scrollbar states
    void SetAudioState()
    {
        // Set the initial audio state to be not paused (sound on) by default
        AudioListener.pause = false;

        // Set the toggle's initial state to match the audio state
        if (toggle != null)
        {
            toggle.isOn = !AudioListener.pause;
        }
    }

    // Set the initial volume based on the scrollbar value
    void SetVolume()
    {
        // Set the initial volume based on the scrollbar value
        if (scrollbar != null)
        {
            AudioListener.volume = 1.0f - scrollbar.value;
        }
    }
}
