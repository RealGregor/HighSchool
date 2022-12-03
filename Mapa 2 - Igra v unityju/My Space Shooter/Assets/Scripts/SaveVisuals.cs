using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveVisuals : MonoBehaviour {
	public Slider thisSlider;
	public Slider thatSlider;
	// Use this for initialization
	public void Change () {
		thisSlider.value = thatSlider.value;
	}
}
