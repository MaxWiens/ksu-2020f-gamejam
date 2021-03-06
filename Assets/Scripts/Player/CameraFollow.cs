﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public static float LookSpeed = 1f;

	[SerializeField]
	private Transform _cameraParent = null;
	private Vector2 _rotation;

	private const float _vertLookLimit_min = 28;
  private const float _vertLookLimit_max = 34;



	void Start() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		_rotation.y = transform.eulerAngles.y;
		//if(_cameraParent == null)
			//enabled = false;
	}

	void Update() {
		Vector2 camMovement = InputManager.Input.Player.Look.ReadValue<Vector2>() * LookSpeed;
		_rotation.y += camMovement.x;
		_rotation.x += -camMovement.y;
		_rotation.x = Mathf.Clamp(_rotation.x, -_vertLookLimit_min, _vertLookLimit_max);
		_cameraParent.localRotation = Quaternion.Lerp(_cameraParent.localRotation, Quaternion.Euler(_rotation.x, _rotation.y, 0), Time.deltaTime * 25);

		_cameraParent.position = transform.position;
	}
}
