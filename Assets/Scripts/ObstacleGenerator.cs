using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

    public GameObject Obstacle;

	// Use this for initialization
	void Start () {
        ObstacleCreator();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void ObstacleCreator()
    {
        int rnd = Random.Range(1, 5);
        if(rnd == 1)
            GameObject.Instantiate(Obstacle, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
        else if (rnd == 2)
            GameObject.Instantiate(Obstacle, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
        else if (rnd == 3)
            GameObject.Instantiate(Obstacle, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        else if (rnd == 4)
            GameObject.Instantiate(Obstacle, new Vector2(transform.position.x, transform.position.y - 2), Quaternion.identity);

        float time = Random.Range(3, 7);
        Invoke("ObstacleCreator", time);
    }
}
