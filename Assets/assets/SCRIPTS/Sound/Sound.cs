using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public bool localSound; //hear everywere
	public bool soundplayed;
    public AudioMixerGroup sfx;

	public void PlaySound(AudioClip sound) //Sfx
	{
		GameObject soundGameObject = new GameObject("Sound" + " " + gameObject.name);
        soundGameObject.transform.parent = gameObject.transform;
        soundGameObject.transform.localPosition = new Vector3(0f, 0f, 0f);

		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();

		audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.outputAudioMixerGroup = sfx;
        if(!localSound)
        {
            audioSource.spatialBlend = 1f;
            audioSource.maxDistance = 30f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
        }

        audioSource.PlayOneShot(sound);

		Destroy(soundGameObject, sound.length);
	}

	public void PlayTheme(AudioClip theme, Transform parent)
	{
		GameObject soundGameObject = new GameObject("SoundTheme");
		soundGameObject.transform.SetParent(parent);
		AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
		audioSource.loop = true;
		//audioSource.PlayOneShot(theme);
	}
}