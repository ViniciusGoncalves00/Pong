using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    void Start()
    {
        _audioSource.Play();
    }
}