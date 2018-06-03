using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Aeroplane : MonoBehaviour {

    private int score = 0;
    public Text Score, HighScore;
    public GameObject Explosion, ObstacleGenerator;
    public Canvas MenuCanvas, GameplayCanvas;

	// Use this for initialization
	void Start () {
        HighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
    }
	
	// Update is called once per frame
	void Update () {
	    if(GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            float angle = Mathf.Lerp(0, 20, GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else
        {
            float angle = Mathf.Lerp(0, -40, -GetComponent<Rigidbody2D>().velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 9);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "ObstacleCrossed")
        {
            score += 1;
            Score.GetComponent<Text>().text = score.ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (PlayerPrefs.GetInt("HighScore") < score)
            PlayerPrefs.SetInt("HighScore", score);
        GetComponent<PolygonCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        ObstacleGenerator.transform.position = new Vector2(-5, 0);
        HighScore.GetComponent<Text>().text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        MenuCanvas.GetComponent<Canvas>().enabled = true;
        GameplayCanvas.GetComponent<Canvas>().enabled = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, 10);
        GameObject exp = Instantiate(Explosion, new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
        Destroy(exp, 0.58f);
    }

    public void PlayButtonClick()
    {
        MenuCanvas.GetComponent<Canvas>().enabled = false;
        GameplayCanvas.GetComponent<Canvas>().enabled = true;
        transform.position = new Vector3(0, 0, -1);
        GetComponent<PolygonCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().gravityScale = 2.8f;
        ObstacleGenerator.transform.position = new Vector2(5, 0);
        score = 0;
        Score.GetComponent<Text>().text = score.ToString();
    }
}
