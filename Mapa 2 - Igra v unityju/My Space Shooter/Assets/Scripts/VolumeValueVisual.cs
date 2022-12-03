using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueVisual : MonoBehaviour {
	public Text musicText;
	public Text sfxText;
	public Slider musicSlider;
	public Slider sfxSlider;

	public AudioSource musicVolume;
	public AudioSource sfxVolume;

	// Use this for initialization
	void Start () {
		sfxSlider.value = sfxVolume.volume;
		musicSlider.value = musicVolume.volume;
		musicText.text = ""+Mathf.RoundToInt(musicSlider.value * 100);
		sfxText.text = ""+Mathf.RoundToInt(sfxSlider.value * 100);
	}
	
	// Update is called once per frame
	void Update () {
		musicText.text = ""+Mathf.RoundToInt(musicSlider.value * 100);
		sfxText.text = ""+Mathf.RoundToInt(sfxSlider.value * 100);
	}
}
