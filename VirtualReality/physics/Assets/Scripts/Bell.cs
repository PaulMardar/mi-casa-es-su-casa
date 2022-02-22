using UnityEngine;

public class Bell : MonoBehaviour
{
    public AudioSource bellHitAudioSource;


    private void OnCollisionEnter(Collision collision)
    {
        bellHitAudioSource.Play();
    }
}
