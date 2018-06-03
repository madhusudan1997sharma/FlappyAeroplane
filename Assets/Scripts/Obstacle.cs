using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 8);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - 0.03f, transform.position.y);
        if (GameObject.FindGameObjectWithTag("Explosion"))
            Destroy(gameObject);
	}
}
