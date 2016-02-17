using UnityEngine;
using System.Collections;

public class EncounterMover : MonoBehaviour {
	public float speed;
	public float delayAfterMe = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
	}
}
