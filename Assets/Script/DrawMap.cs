using UnityEngine;
using System.Collections;

public class DrawMap : MonoBehaviour {
	public int [][]map;
	public int mapWidth;
	public int mapHeight;
	public GameObject wall;
	public GameObject floor;
	// Use this for initialization
	void Start () {
		map = new int[mapWidth][];
		for (int i = 0; i < mapWidth; i++) {
			map[i] = new int[mapHeight];
			for (int j = 0; j < mapHeight; j++) {
				if (i == 0 || j == 0 || i == mapHeight-1 || j == mapHeight-1) {
					map [i] [j] = 1;
				}
			}
		}
		drawMap ();
	}

	void drawMap(){
		Vector3 pos;
		GameObject wal;
		pos.y = 0f;
		for (int i = -24; i < 25; i++) {
			for (int j = -24; j < 25; j++) {
				pos.x = (float)i*5;
				pos.z = (float)j*5;
				wal = (GameObject)Instantiate (floor, pos, Quaternion.identity);
				wal.transform.SetParent (this.transform);
			}
		}
		pos.y = 2.6f;
		for (int i = 0; i < mapWidth; i++) {
			for (int j = 0; j < mapHeight; j++) {
				pos.x = (float)i-(mapWidth/2+0.5f);
				pos.z = (float)j-(mapWidth/2+0.5f);
				switch(map[i][j]){
				case 0:
					break;
				case 1:
					wal = (GameObject)Instantiate (wall, pos, Quaternion.identity);
					wal.transform.SetParent (this.transform);
					break;
				}
			}
		}
	}
}
