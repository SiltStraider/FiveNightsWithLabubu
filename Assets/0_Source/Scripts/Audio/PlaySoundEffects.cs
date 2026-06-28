using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundEffects : MonoBehaviour
{
   private AudioSource audioSource;

   private void Start()
   {
      audioSource = GetComponent<AudioSource>();
   }

   public void PlayEffect(AudioClip audio)
   {
      audioSource.PlayOneShot(audio);
   }
}
