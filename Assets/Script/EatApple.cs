using UnityEngine;
using System.Collections;

public class EatApple : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other){
		other.transform.parent.GetComponent<Player>().addFood();
		other.transform.parent.Find("Status").transform.Find("shengji").GetComponent<donghua>().start();
		this.gameObject.SetActive (false);
	}
}
