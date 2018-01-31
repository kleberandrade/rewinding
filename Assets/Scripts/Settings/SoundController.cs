using UnityEngine;
using System.Collections;

public enum soundsGame{
	click
}

public class SoundController : MonoBehaviour {
	
	public AudioClip soundClick;
    public static SoundController instance;
	
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	public static void PlaySound(soundsGame currentSound)
    {
        switch (currentSound)
        {
		    case soundsGame.click:
                {
			        instance.GetComponent<AudioSource>().PlayOneShot(instance.soundClick);
		        }
			    break;
        }
	}

    public static void StopSound(soundsGame currentSound)
    {
        switch (currentSound)
        {
            case soundsGame.click:
                {
                    instance.GetComponent<AudioSource>().Stop();
                }
                break;
        }
    }
}

