using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance => _instance;
    private void Awake()
    {
        _instance = this;
    }

    private AudioSource soundSource;
    private AudioClip pickUpMoney => Resources.Load<AudioClip>("Sounds/pickup");
    private AudioClip gameOver => Resources.Load<AudioClip>("Sounds/trigger");
    private AudioClip jump => Resources.Load<AudioClip>("Sounds/jump");
    private AudioClip GiveFigure => Resources.Load<AudioClip>("Sounds/givefigure");
    private AudioClip BoostSpeed => Resources.Load<AudioClip>("Sounds/boostSpeed");
    private AudioClip _finish => Resources.Load<AudioClip>("Sounds/levelup");
    private AudioClip takehit => Resources.Load<AudioClip>("Sounds/hit");
    private AudioClip deathEnemy => Resources.Load<AudioClip>("Sounds/death");
    public AudioSource SoundSource
    {
        get
        {
            if (soundSource == null)
            {
                GameObject[] objects = FindObjectsOfType<GameObject>();
                GameObject player = null;

                foreach (GameObject p in objects)
                {
                    if (p.name == "player") player = p;
                }

                foreach (AudioSource audioSource in player.transform.GetComponentsInChildren<AudioSource>())
                {
                    if (audioSource.gameObject.name == "SoundSource")
                    {
                        soundSource = audioSource;
                    }
                }
            }
            return soundSource;
        }
    }

    public void Play(AudioSource src, AudioClip clip)
    {
        //src.clip = clip;
        src.PlayOneShot(clip);
    }
   
    public void PickUpMoney()
    {
        Play(SoundSource, pickUpMoney);
    }
    public void GameOver()
    {
        Play(SoundSource, gameOver);
    }
    public void Jump()
    {
        Play(SoundSource, jump);
    }
    public void GigureGive()
    {
        Play(SoundSource, GiveFigure);
    }
    public void SpeedBoost()
    {
        Play(SoundSource, BoostSpeed);
    }

    public void Finish()
    {
        Play(SoundSource, _finish);
    }

    public void TakeHit()
    {
        Play(SoundSource, takehit);
    }

    public void EnemyDestroyed()
    {
        Play(SoundSource, deathEnemy);
    }

    public void Stop()
    {
        SoundSource.Stop();
    }

}


