using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour {
	public AudioSource[] music;
	public AudioSource[] sfx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetMusicVolume(float musicVolume){
		foreach(var v in music){
			v.volume = musicVolume;
		}
	}
	public void SetSFXVolume(float sfxVolume){
		foreach(var v in sfx){
			v.volume = sfxVolume;
		}
	}
}
