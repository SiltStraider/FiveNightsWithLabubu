using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToggleDoorAnimation : InteractObject
{
    public AudioClip openDoorAudio;
    public AudioClip closeDoorAudio;
    public PlaySoundEffects playSoundEffects;
    
    private string nameOpenAnimation = "Close";
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    private void OnMouseDown()
    {
        if (EventSystem.current != null &&
            EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        OnClick();
    }

    public void OnClick()
    {
        if (!ChekInteract())
            return;

        IsActive = !IsActive;
        animator.SetBool(nameOpenAnimation, IsActive);

        if (IsActive == false)
            playSoundEffects.PlayEffect(openDoorAudio);
        else
            playSoundEffects.PlayEffect(closeDoorAudio);
    }
}
