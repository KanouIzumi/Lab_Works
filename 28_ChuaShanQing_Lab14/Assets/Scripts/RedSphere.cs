using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedSphere : MonoBehaviour
{
    public GameObject RedCountText;

    public int RedTouch;

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
            RedTouch++;
            audioSource.Play();
            RedCountText.GetComponent<Text>().text = "Red: " + RedTouch;
            Debug.Log("Red");
        }
    }
}
