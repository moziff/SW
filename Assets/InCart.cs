using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCart : MonoBehaviour {

	public RawImage image;
	public Text cart;

	private int id;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void PutInCart(){
		cart.text = "Placed In Cart!";
		image.gameObject.SetActive (true);
	}
}
