using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	public float scroll;
	public float tileSizedY;

	private Vector3 position;


	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scroll, tileSizedY);
		transform.position = position + Vector3.up * newPosition;
	}
}
