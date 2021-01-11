using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleYellow : MonoBehaviour
{
    public GameObject YellowCountText;

    public int YellowTouch;

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
            YellowTouch++;
            audioSource.Play();
            YellowCountText.GetComponent<Text>().text = "Yellow: " + YellowTouch;
            Debug.Log("Yellow");
        }
    }
}
