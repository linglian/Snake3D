using UnityEngine;
using System.Collections;

public class DrawMap : MonoBehaviour {
	public int [][]map;
	public GameObject wall;
	// Use this for initialization
	void Start () {
		map = new int[50][];
		for (int i = 0; i < 50; i++) {
			map[i] = new int[50];
			for (int j = 0; j < 50; j++) {
				if (i == 0 || j == 0 || i == 49 || j == 49) {
					map [i] [j] = 1;
				}
			}
		}
		drawMap ();
	}

	void drawMap(){
		Vector3 pos;
		pos.y = 2.6f;
		for (int i = 0; i < 50; i++) {
			for (int j = 0; j < 50; j++) {
				pos.x = (float)i-25.5f;
				pos.z = (float)j-25.5f;
				switch(map[i][j]){
				case 0:
					break;
				case 1:
					Instantiate (wall, pos,Quaternion.identity);
					break;
				}
			}
		}
	}
}
