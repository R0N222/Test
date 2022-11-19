using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private List<Sound> sounds = new List<Sound>();
	[SerializeField]
	private AudioSource audioSource;

	public static AudioManager instance;

	public void Awake()
	{
		instance = this;
	}




	public static void Play(string name)
	{
		foreach ( Sound s in instance.sounds)
		{
			if(s.Name == name)
			{
				instance.audioSource.PlayOneShot(s.clip,s.volume);

			}
		}
	} 
}


[System.Serializable]
public class Sound
{
	public string Name;
	public AudioClip clip;
	public float volume;

}