using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;

public class AudioManagerSript : MonoBehaviour
{
    public static AudioClip Laser_Shoot, EnemyDeathSound, Boost, GameOver,BossDeathSound,Boss_Shoot;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        GameOver = Resources.Load<AudioClip>("Game_Over");
        Laser_Shoot = Resources.Load<AudioClip>("Laser_Shoot");
        Boost = Resources.Load<AudioClip>("Boost");
        EnemyDeathSound = Resources.Load<AudioClip>("EnemyDeathSound");
        audioSrc = GetComponent<AudioSource>();
        BossDeathSound = Resources.Load<AudioClip>("BossDeathSound");
        Boss_Shoot = Resources.Load<AudioClip>("Boss_Shoot");
    }

    static public void playSound(string clip)
	{
        audioSrc.volume = 1f;
        switch (clip) {
            case "Game_Over":
                GameObject.Find("MusicManager").GetComponent<MusicManager>().endMusic();
                audioSrc.volume = 0.1f;
                audioSrc.PlayOneShot(GameOver);
                break;
            case "Laser_Shoot":
                audioSrc.PlayOneShot(Laser_Shoot);
                break;
            case "Boost":
                audioSrc.PlayOneShot(Boost);
                break;
            case "enemyDeathSound":
                audioSrc.PlayOneShot(EnemyDeathSound);
                break;
            case "BossDeathSound":
                audioSrc.PlayOneShot(BossDeathSound,0.1f);
                break;
            case "Boss_Shoot":
                audioSrc.PlayOneShot(Boss_Shoot, 0.1f);
                break;
        }
	}
}
