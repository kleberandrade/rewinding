using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : Singleton<ScreenManager> 
{
	[Header("Fade In/Out")]
	[SerializeField]
	private CrossFadeAlphaUI m_FadeUI;

	[SerializeField]
	private float m_TransitionTime = 0.8f;

	[Header("Loading")]
	[SerializeField]
	private CrossFadeAlphaUI m_LoadUI;

	[SerializeField]
	private RandomImageUI m_LoadImageUI;

	[SerializeField]
	private float m_LoadingTime = 5.0f;

	private bool m_FirstLoading = true;

	private string m_NextSceneName = string.Empty;

	private Canvas m_Canvas;

	private void OnEnable()
	{
		SceneManager.activeSceneChanged += OnSceneWasLoaded;
	}

	private IEnumerator Hide()
	{
		yield return new WaitForSeconds (m_FadeUI.FadeTime);
		m_Canvas.sortingOrder = -100;
	}

	private void Start()
	{
		StartCoroutine (Hide ());
	}

	private void OnDisable()
	{
		SceneManager.activeSceneChanged -= OnSceneWasLoaded;
	}

	private void OnSceneWasLoaded(Scene result, Scene checkSceneLoaded)
	{
		if (checkSceneLoaded.isLoaded && checkSceneLoaded.name.Equals(m_NextSceneName)) 
		{
			StartCoroutine (ExitFade ());
		}
	}

	public override void Awake ()
	{
		base.Awake ();
		m_Canvas = GetComponent<Canvas> ();
	}

	private IEnumerator ExitFade()
	{
		m_NextSceneName = string.Empty;
		if (!m_FirstLoading) {
			m_LoadUI.Fade ();
			yield return new WaitForSeconds (m_TransitionTime);
		}
			
		m_FadeUI.Fade ();

		yield return new WaitForSeconds (m_FadeUI.FadeTime);

		m_Canvas.sortingOrder = -100;
	}

	private IEnumerator ExecuteFade () 
	{
		if (m_FirstLoading) {
			m_FirstLoading = !m_FirstLoading;
		}
			
		m_FadeUI.Fade();

		yield return new WaitForSeconds (m_FadeUI.FadeTime);

		m_LoadImageUI.Change ();
		m_LoadUI.Fade();
		yield return new WaitForSeconds (m_LoadUI.FadeTime);

		SceneManager.LoadScene(m_NextSceneName);
		yield return null;
	}

	public void LoadScene(string sceneName)
	{
		m_Canvas.sortingOrder = 100;
		m_NextSceneName = sceneName;
		StartCoroutine (ExecuteFade());
	}
}