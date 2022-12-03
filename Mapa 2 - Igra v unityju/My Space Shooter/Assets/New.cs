using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Ulomek a = new Ulomek (2,3);
		Ulomek b = new Ulomek (2,4);
		Ulomek c = a.sestej (b);
		c.izpis ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
	
class Ulomek{
	int st;
	int im;
	public Ulomek(int st, int im){
		this.st = st;
		this.im = im;
	}
	public Ulomek(){
		this.st = 0;
		this.im = 0;
	}

	public Ulomek sestej(Ulomek a){
		Ulomek c = new Ulomek ();
		int stevec = this.st * a.im + this.im * a.st;
		int imenovalec = this.im * a.im;
		c.st = stevec;
		c.im = imenovalec;
		return c;
	}

	public void izpis(){
		Debug.Log (this.st + "/" + this.im);
	}

}

