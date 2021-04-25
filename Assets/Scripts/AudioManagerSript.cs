using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class AudioManagerSript : MonoBehaviour
{
    public static AudioClip eat, jumpSound, death;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        eat = Resources.Load<AudioClip>("slurpShort");
        jumpSound = Resources.Load<AudioClip>("jumpSound");
        death = Resources.Load<AudioClip>("Air Woosh Underwater");
        audioSrc = GetComponent<AudioSource>();
       
    }

    static public void playSound(string clip)
	{
        audioSrc.volume = 1f;
        switch (clip) {
            case "death":
                GameObject.Find("MusicManager").GetComponent<MusicManager>().endMusic();
                audioSrc.volume = 0.1f;
                audioSrc.PlayOneShot(death);
                break;
            case "eat":
                audioSrc.PlayOneShot(eat);
                break;
            case "jumpSound":
                audioSrc.PlayOneShot(jumpSound);
                break;
        }
	}
}
