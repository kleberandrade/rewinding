using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {
	
	[Header("Game Objetos hud do jogo")]
	[Space(10)]		

	[SerializeField] 
	private GameObject m_GameUI;

	[SerializeField]
	private GameObject m_PauseUI;

	private CrossFadeAlphaUI m_FadeImageUI;

	[SerializeField]
	private string m_MenuSceneName = "MainMenu";

	private bool m_IsPaused;

	private void Start () 
	{
		m_FadeImageUI = m_PauseUI.GetComponent<CrossFadeAlphaUI> ();

		m_IsPaused = false;

		if (m_GameUI)
			m_GameUI.SetActive (true);

		if (m_PauseUI)
			m_PauseUI.SetActive (false);
	}

	public void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Pause ();
		}
	}

	public void ExitToMainMenu()
	{
		Time.timeScale = 1;
		ScreenManager.Instance.LoadScene (m_MenuSceneName);
	}

	public void Pause()
	{
		if (m_IsPaused)
			Hide ();
		else
			Show ();
	}

	[ContextMenu("Hide")]
	public void Hide()
	{
		StartCoroutine (Hiding ());
	}

	private IEnumerator Hiding()
	{
		Time.timeScale = 1;
	
		yield return StartCoroutine (m_FadeImageUI.ExecuteFade ());

		if (m_PauseUI)
			m_PauseUI.SetActive (false);

		if (m_GameUI)
			m_GameUI.SetActive (true);

		m_IsPaused = false;
	}

	[ContextMenu("Show")]
	public void Show()
	{
		StartCoroutine (Showing ());
	}

	private IEnumerator Showing()
	{
		if (m_GameUI)
			m_GameUI.SetActive (false);

		if (m_PauseUI)
			m_PauseUI.SetActive (true);

		yield return StartCoroutine (m_FadeImageUI.ExecuteFade ());

		Time.timeScale = 0;

		m_IsPaused = true;
	}
}
