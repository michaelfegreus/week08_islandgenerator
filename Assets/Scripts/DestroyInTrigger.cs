using UnityEngine;
using System.Collections;

public class DestroyInTrigger : MonoBehaviour {

	bool pleaseDestroy = false;

	void OnTriggerEnter(Collider col) {
		if (col.tag == ("EdgeBox") || col.tag == ("Pathmaker")) {
			pleaseDestroy = true;
		}
	}
	void OnTriggerStay(Collider col) {
		if (col.tag == ("EdgeBox") || col.tag == ("Pathmaker")) {
			pleaseDestroy = true;
		}
	}

	void Update () {
		if (pleaseDestroy) {
			Destroy (gameObject);
		}
	}
}
