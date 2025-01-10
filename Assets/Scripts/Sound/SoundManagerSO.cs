using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "SoundManagerData", menuName = "Managers/Sound Manager Data")]
public class SoundManagerSO : ScriptableObject
{
	[Header("Master Volumes")]
	[Range(0f, 1f)] public float masterMusicVolume = 1f;
	[Range(0f, 1f)] public float masterUIVolume = 1f;

	[Header("Music Clips")]
	public List<AudioClip> musicClips;

	[Header("UI Clips")]
	public List<AudioClip> uiClips;
}
