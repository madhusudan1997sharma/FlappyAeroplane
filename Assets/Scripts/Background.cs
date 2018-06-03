using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector2(transform.position.x - 0.008f, transform.position.y);

        if(transform.position.x <= -8.5f)
        {
            transform.position = new Vector2(8.6f, 0);
        }
	}
}
