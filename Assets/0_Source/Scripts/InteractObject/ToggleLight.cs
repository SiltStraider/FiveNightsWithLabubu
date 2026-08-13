using System;
using UnityEngine;

public class ToggleLight : InteractObject
{
    public AudioClip lightOnAudio;
    public AudioClip lightOffAudio;
    public PlaySoundEffects playSoundEffects;
    public GameObject light;

    private void Start()
    {
        light.SetActive(false);
    }

    private void OnMouseDown()
    {
        OnClick();
    }
    
    public void OnClick()
    {
        if(ChekInteract() == false) return;
        
        IsActive = !IsActive;
        light.SetActive(IsActive);

        if (IsActive == true) playSoundEffects.PlayEffect(lightOnAudio);
        else playSoundEffects.PlayEffect(lightOffAudio);
    }
        
}
