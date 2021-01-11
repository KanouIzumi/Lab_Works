using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleOrange : MonoBehaviour
{
    public GameObject OrangeCountText;

    public int OrangeTouch;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OrangeTouch++;
            audioSource.Play();
            OrangeCountText.GetComponent<Text>().text = "Yellow: " + OrangeTouch;
            Debug.Log("Yellow");
        }
    }
}
