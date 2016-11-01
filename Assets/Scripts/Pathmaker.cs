using UnityEngine;
using System.Collections;

public class Pathmaker : MonoBehaviour {

	public static int maxTiles = 1500;

	private int counter;
	public Transform floorPrefab;
	public Transform tallGrassPrefab;
	public Transform rockPrefab;
	public Transform pathmakerSpherePrefab;
	float cooridoorLikelihoodPercent; // Can tune cooridoor chance here
	float squareAreaChance;

	float turnThreshold = .25f;
	float turnCap = .5f;

	bool doNotSpawn = false;

	void OnTriggerEnter(Collider col) {
		if (col.tag == ("EdgeBox")) {
			doNotSpawn = true;
		}
	}
	void OnTriggerStay(Collider col) {
		if (col.tag == ("EdgeBox")) {
			doNotSpawn = true;
		}
	}
	void OnTriggerExit(Collider col) {
		if (col.tag == ("EdgeBox")) {
			doNotSpawn = false;
		}
	}

	// Use this for initialization
	void Start () {
		cooridoorLikelihoodPercent = Random.Range (0f, 30f);
		squareAreaChance = Random.Range (0f, 1f);
		if (squareAreaChance < .25f) { // Can tune squares here by increasing or decreasing chance
			turnThreshold = .1f;
			turnCap = .8f;
		}
		if (50f < cooridoorLikelihoodPercent) {
			counter = Random.Range (25, 41);
		} else {
			counter = Random.Range (50, 101);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (maxTiles < 1) {
			Destroy (gameObject);
		}
		if (0 < counter) {
			float randomFloat = Random.Range (0f, 1f);
			float randomCooridorFloat = Random.Range (0f, 1f);
			if (randomFloat < turnThreshold && cooridoorLikelihoodPercent/100 < randomCooridorFloat) {
				transform.Rotate (0, 90, 0);
			} else if (turnThreshold < randomFloat && randomFloat < turnCap && cooridoorLikelihoodPercent/100 < randomCooridorFloat) {
				transform.Rotate (0, -90, 0);
			} else if (.99f < randomFloat) {
				Instantiate (pathmakerSpherePrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
			}
			transform.Translate (0f, 0f, 5f);
			//if (!doNotSpawn) {
				if (randomFloat < .02f) {
					Instantiate (rockPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
				} else if (.1f < randomFloat && randomFloat < .25f) {
					Instantiate (tallGrassPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
				} else {
					Instantiate (floorPrefab, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), gameObject.transform.rotation);
				}
				counter--;
				maxTiles--;
			//}
		} else {
			Destroy (gameObject);
		}
	}
}