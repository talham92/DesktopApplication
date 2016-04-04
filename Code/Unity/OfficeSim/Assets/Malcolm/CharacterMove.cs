﻿
using UnityEngine;
using System.Collections;

public class CharacterMove: MonoBehaviour {
	private Rigidbody rb;
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;

	void Start(){
	rb = GetComponent<Rigidbody>();
	}




	void Update() {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		//translation *= Time.deltaTime;
		//rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
	}
}
