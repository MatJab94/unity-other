using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	int currentScore = 0;
	public Text score;

	void OnTriggerEnter2D(Collider2D collision)
	{
		currentScore++;
		score.text = currentScore.ToString();

		Ball script = collision.gameObject.GetComponent<Ball>();
		script.ResetBall();
	}
}
