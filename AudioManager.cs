using UnityEngine;

public class AudioManager : MonoBehaviour
{
   
    [SerializeField] AudioSource SFXSource;
    public AudioClip death;




    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }
}
