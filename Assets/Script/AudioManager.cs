using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance { get { return instance; } }

    [SerializeField] AudioSource audioSource;
    //[SerializeField] AudioSource backAudioSource;
    [SerializeField] AudioClip m_PlayerDie,m_EnemeyDie ,music;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        //backAudioSource = GetComponent<AudioSource>();
        //BackGroundMusic();
    }
    public void BackGroundMusic()
    {
        audioSource.clip = music;
        audioSource.Play();
    }
    public void PlayerDie()
    {
        audioSource.clip = m_PlayerDie;
        audioSource.Play();
    }
    public void EnemyDie()
    {
        audioSource.clip = m_EnemeyDie;
        audioSource.Play();
    }
}
