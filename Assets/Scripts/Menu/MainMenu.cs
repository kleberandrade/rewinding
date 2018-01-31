using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
	[Header("Panels")]
	[SerializeField]
	private GameObject m_IntroPanel;

	[SerializeField]
	private GameObject m_MenuPanel;

	[SerializeField]
	private GameObject m_CreditsPanel;

	[SerializeField]
	private GameObject m_SettingsPanel;

	private bool m_PressAnyKey = true;

	private void Update () 
	{
		if (m_PressAnyKey) 
		{
			if (Input.touchCount > 0 || Input.anyKeyDown) {
				ShowMenu ();
				m_PressAnyKey = false;
			}
		}

		if (m_MenuPanel.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape)) 
		{
			Quit ();
		}
	}

	public void PlayGame()
	{
        SoundController.PlaySound(soundsGame.click);
		ScreenManager.Instance.LoadScene ("Gameplay");
	}

	public void ShowMenu()
    {
        SoundController.PlaySound(soundsGame.click);
        m_IntroPanel.SetActive (false);
		m_MenuPanel.SetActive (true);
		m_CreditsPanel.SetActive (false);
		m_SettingsPanel.SetActive (false);
	}

	public void ShowCredits()
    {
        SoundController.PlaySound(soundsGame.click);
        m_IntroPanel.SetActive (false);
		m_MenuPanel.SetActive (false);
		m_CreditsPanel.SetActive (true);
		m_SettingsPanel.SetActive (false);
	}

	public void ShowSettings()
    {
        SoundController.PlaySound(soundsGame.click);
        m_IntroPanel.SetActive (false);
		m_MenuPanel.SetActive (false);
		m_CreditsPanel.SetActive (false);
		m_SettingsPanel.SetActive (true);
	}

	public void Quit()
    {
        SoundController.PlaySound(soundsGame.click);
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit ();
		#endif
	}
}
