using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	GameObject holes;

	float velocityThreshold1 = 5f;
	float velocityThreshold2 = 7.5f;
	float velocityThreshold3 = 10f;

	public void Awake() {
		Transform[] children = gameObject.GetComponentsInChildren<Transform>();
		foreach (Transform child in children) {
			if (child.name == "Holes") {
				holes = child.gameObject;
			}
		}
	}

	public void Update() {
		holes.transform.Rotate(((new Vector3(rigidbody.velocity.y, 0f, -rigidbody.velocity.x)).normalized) * (rigidbody.velocity.magnitude * 50f * Time.deltaTime));

		//Debug.Log(rigidbody.velocity.magnitude);

		float v = rigidbody.velocity.magnitude;
		if (v > velocityThreshold3) {
			rigidbody.drag = 2f;
		} else if (v > velocityThreshold2) {
			rigidbody.drag = 0.2f;
		} else if (v > velocityThreshold1) {
			rigidbody.drag = 0.1f;
		} else {
			rigidbody.drag = 0.05f;
		}
	}

	public void Roll(Vector2 v) {
		rigidbody.AddForce((Vector3)v, ForceMode.VelocityChange);
	}
}
