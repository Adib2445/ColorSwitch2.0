using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {


	public float jumpForce = 3f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;

	public string currentColor;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	public static int score = 0;
	public Text ScoreText;

	public GameObject ColorChanger;
	public GameObject obstacle;

    
	void Start ()
	{
		SetRandomColor();
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
		{
			rb.velocity = Vector2.up * jumpForce;
		}

		ScoreText.text = score.ToString ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.tag == "Score") {
			score++;
			Destroy (col.gameObject);
			Instantiate (obstacle , new Vector2(transform.position.x,transform.position.y + 10f), transform.rotation);
			return;
		}


		if (col.tag == "ColorChanger")
		{
			SetRandomColor();
			Destroy(col.gameObject);
			Instantiate (ColorChanger, new Vector2(transform.position.x,transform.position.y + 15f), transform.rotation); 
			return;
		}

		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			score = 0; 
		}
	}

	void SetRandomColor ()
	{
		int index = Random.Range(0, 4);

		switch (index)
		{
		case 0:
			currentColor = "Blue";
			sr.color = colorCyan;
			break;
		case 1:
			currentColor = "yellow";
			sr.color = colorYellow;
			break;
		case 2:
			currentColor = "purple";
			sr.color = colorMagenta;
			break;
		case 3:
			currentColor = "Pink";
			sr.color = colorPink;
			break;
		}
	}



}
