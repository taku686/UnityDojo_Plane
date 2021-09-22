using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Fighter : MonoBehaviour
{
	public float target_kmph_ = 100f;
	private Rigidbody rigidbody_;
	private string enemy_tag_;

	void Start()
	{
		rigidbody_ = GetComponent<Rigidbody>();
		var my_tag = gameObject.tag;
		if (my_tag == "blue") {
			enemy_tag_ = "green";
		} else {
			enemy_tag_ = "blue";
		}
	}

	void FixedUpdate()
	{
		GameObject nearest_go = null;
		var my_pos = transform.position;
		{
			var min_dist2 = Mathf.Infinity;
			var enemies = GameObject.FindGameObjectsWithTag(enemy_tag_);
			for (var i = 0; i < enemies.Length; ++i) {
				var enemy = enemies[i];
				var diff = enemy.transform.position - my_pos;
				var mag2 = diff.sqrMagnitude;
				if (mag2 < min_dist2) {
					nearest_go = enemy;
					min_dist2 = mag2;
				}
			}			
		}

		var forward = transform.TransformVector(Vector3.forward);

		if (nearest_go != null) {
			var dir = nearest_go.transform.position - my_pos;
			rigidbody_.AddTorque(Vector3.Cross(forward, dir)*50f);
		}
	
		rigidbody_.AddTorque(Vector3.Cross(forward, -my_pos)*5f);

		var left = transform.TransformVector(Vector3.left);
		var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
		var horizontal_left = Vector3.Cross(Vector3.up, horizontal_forward);
		rigidbody_.AddTorque(Vector3.Cross(forward, horizontal_forward)*2f);
		rigidbody_.AddTorque(Vector3.Cross(horizontal_left, left)*2f);

		float dt = Time.fixedDeltaTime;
		float drag = rigidbody_.drag;
		float mass = rigidbody_.mass;
		float force = (target_kmph_/3600f*1000f) * (drag * mass /  (1f - drag*dt));
		rigidbody_.AddForce(transform.TransformVector(new Vector3(0f, 0f, force)));
	}

}
