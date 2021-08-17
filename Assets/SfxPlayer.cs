using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SfxPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;
    
    private AudioSource _source;
    
    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _source.clip = clips[Random.Range(0, clips.Length)];
        _source.Play();        
    }
}
