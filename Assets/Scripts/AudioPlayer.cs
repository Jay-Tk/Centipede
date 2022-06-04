using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip eatingClip;
    [SerializeField] [Range(0f, 1f)] float eatingVolume = 1f;
    //[SerializeField] AudioClip damageClip;
    //[SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length;
        //if (instanceCount > 1)
        if (instance)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayEatingClip()
    {
        PlayClip(eatingClip, eatingVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
