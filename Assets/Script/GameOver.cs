using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		GameObject.Find("Player").GetComponent<Player> ().gameOver ();
	}
}
