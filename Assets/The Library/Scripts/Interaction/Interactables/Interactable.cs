using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private AudioSource MyAudioSource;

    public virtual void Use()
    {
        MyAudioSource.Play();
    }
    public virtual void StopUsing(){}
}
