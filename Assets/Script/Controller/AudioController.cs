using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{


    [SerializeField] AudioClip audio;
    [SerializeField] private string tag;
    [SerializeField] private bool UseVelocity = true;
    [SerializeField] private float min = 0;
    [SerializeField] private float max = 2;

    private AudioSource audioSource;
    private bool kondisi;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag) )
        {
            kondisi = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag) )
        {
            VelocityEstimator ve = other.GetComponent<VelocityEstimator>();
            if (ve && UseVelocity) { 
                float v  = ve.GetVelocityEstimate().magnitude;
                float volume  = Mathf.InverseLerp(min, max, v);
                audioSource.PlayOneShot(audio,volume);

            }
            else
            audioSource.PlayOneShot(audio);
        }
    
    }
  
}
