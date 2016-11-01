using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Pathmaker.maxTiles = 1500;
			SceneManager.LoadScene (0);
		}
	}
}
