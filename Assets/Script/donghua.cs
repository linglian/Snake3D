using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class donghua : MonoBehaviour {
	public Texture2D []texture;
	public bool isFirst;
	public float speedSec = 1;
	float nowTime = 0;
	RawImage image;
	// Use this for initialization
	void Start () {
		image = this.GetComponent<RawImage>();
		image.enabled = isFirst;
	}

	public void start(){
		image.enabled = true;
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (image.enabled) {
			int time = (int)(nowTime*texture.Length);
			nowTime += (Time.deltaTime/speedSec);
			image.texture = texture [time];
			if (time >= texture.Length - 1) {
				nowTime = 0;
				image.enabled = false;
			}
		}
	}
}
