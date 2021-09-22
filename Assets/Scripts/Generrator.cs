using UnityEngine;
using System.Collections;

public class Generrator : MonoBehaviour {

	public GameObject green_prefab_;
	public GameObject blue_prefab_;

	void Start ()
	{
		var num = 100;

		var green_base = new Vector3(1000f, 0f, 0f);
		var green_rot = Quaternion.Euler(0f, 180f, 0f);
		for (var i = 0; i < num; ++i) {
			var pos = new Vector3(Random.Range(-200f, 200f),
								  Random.Range(-100f, 100f),
								  Random.Range(-100f, 100f)) + green_base;
			Instantiate(green_prefab_, pos, green_rot);
		}

		var blue_base = new Vector3(-1000f, 0f, 0f);
		var blue_rot = Quaternion.Euler(0f, 0f, 0f);
		for (var i = 0; i < num; ++i) {
			var pos = new Vector3(Random.Range(-200f, 200f),
								  Random.Range(-100f, 100f),
								  Random.Range(-100f, 100f)) + blue_base;
			Instantiate(blue_prefab_, pos, blue_rot);
		}
	}
}
