using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePanel : MonoBehaviour {

	[SerializeField]
	private Transform root;

	[SerializeField]
	private Image image;

	[SerializeField]
	private Text curScoreText, bestScoreText;

	[SerializeField]
	private Button retryButton, quitButton, nextLevelButton;

	[SerializeField]
	private Text mainText;
	
	[SerializeField]
	private Player player;

	private void Start(){
		retryButton.onClick.AddListener(Retry);
		quitButton.onClick.AddListener(Quit);
		nextLevelButton.onClick.AddListener(NextLevel);
		root.gameObject.SetActive(false);
	}

	public void InitWin(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		mainText.text = "You Win";
		image.color = Color.green;
		isEnd = false;
		if(SceneManager.GetActiveScene().name != "level2")nextLevelButton.gameObject.SetActive(true);

		curScoreText.text = "YOUR SCORE " + curScore.ToString("0");
		bestScoreText.text = "BEST SCORE " + bestScore.ToString("0");
	}

	public void InitLose(float curScore, float bestScore, bool isEnd){
		root.gameObject.SetActive(true);
		mainText.text = "You Lose";
		image.color = Color.red;
		isEnd = false;

		curScoreText.text = "YOUR SCORE " + curScore.ToString("0");
		bestScoreText.text = "BEST SCORE " + bestScore.ToString("0");
	}

	private void Retry(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);		
	}

	private void NextLevel(){
		SceneManager.LoadScene("level2");
	}

	private void Quit(){
		Application.Quit();
	}

	private void OnDestroy() {
		retryButton.onClick.RemoveAllListeners();
		quitButton.onClick.RemoveAllListeners();
	}

}
