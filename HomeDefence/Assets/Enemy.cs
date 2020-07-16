using UnityEngine;

public class Enemy : MonoBehaviour {

	float speed = 10f;

	private Transform target;
	private int wavepointIndex = 0; // enemy go through 0th index wavePoint to 11th wavePoint index

	void Start(){
	
		target = WayPoints.points[0];
	}

	void Update(){
	
		Vector3 dir = target.position - transform.position;
		transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.2f) {
		
			GetNextWayPoint();
		}
	}

	void GetNextWayPoint(){
	
		if (wavepointIndex >= WayPoints.points.Length - 1) {
		
			Destroy (gameObject); // when end enemy reach to the end enemy will bw destroied 	
			return;
		}

		wavepointIndex++;
		target = WayPoints.points[wavepointIndex];
	}
}
