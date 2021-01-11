using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleSphere : MonoBehaviour
{

    public GameObject PurpleCountText;

    public int PurpleTouch;

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
            PurpleTouch++;
            audioSource.Play();
            PurpleCountText.GetComponent<Text>().text = "Purple: " + PurpleTouch;
            Debug.Log("Red");
        }
    }
}
