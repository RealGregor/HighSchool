using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveVolume : MonoBehaviour {
	public Slider musicSlider;
	public Slider sfxSlider;
	public AudioSource demoSFX;

	private float delta;
	private float nextPlay;

	private VolumeController volumeController;

	void Start(){
		volumeController = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VolumeController>();
	}

	public void SendMusicValue(){
		if(volumeController == null){
			volumeController = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VolumeController>();	
		}
		volumeController.SetMusicVolume (musicSlider.value);
	}
	public void SendSFXValue(){
		if(volumeController == null){
			volumeController = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VolumeController>();	
		}
		volumeController.SetSFXVolume (sfxSlider.value);
		demoSFX.volume = sfxSlider.value;
		if (Time.unscaledTime >= nextPlay && nextPlay != 0) {
			Debug.Log ("dingaling changing");
			nextPlay = Time.unscaledTime + 0.1f;
			demoSFX.PlayOneShot (demoSFX.clip);
		} else if(nextPlay == 0){
			nextPlay = Time.unscaledTime;
		}
	}
}
