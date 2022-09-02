using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Sound
{
    public Sound(GameObject prefab, AudioClip clip)
    {
        this.prefab = prefab;
        this.clip = clip;
    }
    public GameObject prefab;
    public AudioClip clip;
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{


    public static SoundManager Instance { get; private set; }

    public Dictionary<string, Sound> Sounds;
    public AudioClip BGM;
    private AudioSource _audio;

    void BuildDictionary(Transform root, string path = "")
    {
        if (Sounds == null)
            Sounds = new Dictionary<string, Sound>();
        for (int i = 0; i < root.childCount; i++)
        {
            Transform child = root.GetChild(i);
            string child_path = path != "" ? path + "/" + child.name.ToLower() : child.name.ToLower();
            AudioSource child_audio = child.GetComponent<AudioSource>();
            if (child_audio)
                Sounds.Add(child_path, new Sound(child.gameObject, child_audio.clip));
            BuildDictionary(child, child_path);
        }
    }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            BuildDictionary(transform);
            Debug.Log("Sounds :");
            foreach (var key in Sounds.Keys)
            {
                Debug.Log(" - " + key);
            }
            _audio = GetComponent<AudioSource>();
            PlayBGM();
        }
    }

    public void PlaySFX(string audioName)
    {
        try
        {
            audioName = audioName.ToLower();
            GameObject sound = Sounds[audioName].prefab;
            PlayOnce(sound);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void Play3DSFX(string name, Vector3 position)
    {

    }

    private void FindSound(string name, Action<Sound> callback)
    {
        try
        {
            name = name.ToLower();
            callback(Sounds[name]);
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void PlayBGM(string name = null)
    {
        if (name == null)
            _audio.clip = BGM;
        else
            FindSound(name, (sound) => _audio.clip = sound.clip);
        _audio.loop = true;
        _audio.Play();

    }

    Transform getTrash()
    {
        Transform trash = gameObject.transform.Find("Trash");

        if (trash == null)
        {
            trash = (new GameObject("Trash")).transform;
            trash.parent = transform;
        }
        return trash;
    }

    void PlayOnce(GameObject sound)
    {
        Transform trash = getTrash();
        GameObject i = Instantiate(sound, trash);
        AudioSource audioSource = i.GetComponent<AudioSource>();

        Destroy(i, audioSource.clip.length);
        audioSource.Play();
    }
}
