using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		angularSpeed = 0;
	}

	private float angularSpeed;
	private bool flag = true;

	float pointA = 3, pointB = -3;
	float translateTimer = 0.0f;

	// Update is called once per frame
	void Update () {
		float dt = Time.deltaTime;

		float currentPoint = pointA * translateTimer + pointB * (1 - translateTimer);

		transform.position = new Vector3 (0, currentPoint, 0);

		translateTimer += dt;

		if (translateTimer > 1.0f) {
			translateTimer = 0.0f;
			float t = pointA;
			pointA = pointB;
			pointB = t;
		}

		transform.Rotate (Vector3.up * angularSpeed * Time.deltaTime, Space.World);

		if (flag) {
			angularSpeed += 360 * dt;
		} else {
			angularSpeed -= 360 * dt;
		}

		if (flag && angularSpeed > 360) {
			flag = false;
		} else if (!flag && angularSpeed < 0) {
			flag = true;
		}
	}
}
