using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Animator操作用
    Animator animator;
    public AudioClip sound;

    //AudioSource操作用
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.animator.SetTrigger("Slash");
            audioSource.PlayOneShot(sound);
        }
    }
}
