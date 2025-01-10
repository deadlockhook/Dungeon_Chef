using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
	* Credits - Joseph MacDonald
	* NSCC - Game Programming Student
	* This script handles logic for UI and Music audio
*/

public class SoundManager : MonoBehaviour
{
	public SoundManagerSO soundManagerData;
	public static SoundManager Instance { get; private set; }

	private AudioSource musicSource;
	private AudioSource uiSource;

	// Singleton
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);

		// Testing atm
		musicSource = gameObject.AddComponent<AudioSource>();
		uiSource = gameObject.AddComponent<AudioSource>();

		musicSource.loop = true;
	}

	// Play UI sound by name
	public static void PlayUIAudio(string clipName, float volume = 1f)
	{
		AudioClip clip = Instance.soundManagerData.uiClips
			.FirstOrDefault(c => c != null && c.name == clipName);

		if (clip == null)
		{
			return;
		}

		float finalVolume = volume * Instance.soundManagerData.masterUIVolume;
		Instance.uiSource.PlayOneShot(clip, finalVolume);
	}

	// Play music track by name
	public static void PlayMusic(string clipName, float volume = 1f, bool loop = true)
	{
		AudioClip clip = Instance.soundManagerData.musicClips
			.FirstOrDefault(c => c != null && c.name == clipName);

		if (clip == null)
		{
			return;
		}

		float finalVolume = volume * Instance.soundManagerData.masterMusicVolume;
		Instance.musicSource.loop = loop;
		Instance.musicSource.volume = finalVolume;
		Instance.musicSource.clip = clip;
		Instance.musicSource.Play();
	}

	public static void StopMusic()
	{
		if (Instance != null && Instance.musicSource.isPlaying)
		{
			Instance.musicSource.Stop();
		}
	}

	// Set master volumes, this will be used in setting menu
	public static void SetMasterVolumes(float musicVol, float uiVol)
	{
		if (Instance == null || Instance.soundManagerData == null) return;

		Instance.soundManagerData.masterMusicVolume = Mathf.Clamp01(musicVol);
		Instance.soundManagerData.masterUIVolume    = Mathf.Clamp01(uiVol);

		// Live changes to vol when changed
		Instance.musicSource.volume = Instance.soundManagerData.masterMusicVolume;
	}
}
