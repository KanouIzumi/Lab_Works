using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    //public GameObject scoreText;
    public GameObject PowerUpCollectedText;
    public float speed;
    //public float score;
    private int PowerUpCount;
    private int totalcount;
    private int PowerUpleft;

    public Rigidbody playerRb;
    public float rotatespeed;

    // Start is called before the first frame update
    void Start()
    {
        totalcount = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        PowerUpCollectedText.GetComponent<Text>().text = "Start Function";
        //scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
        PowerUpCollectedText.GetComponent<Text>().text = "PowerUpCollected: " + PowerUpCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        PowerUpleft = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Debug.Log("Total power Ups left is " + PowerUpleft.ToString());
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) // go forward
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) // go back
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // go left
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // go right
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (PowerUpCount == totalcount)
        {
            SceneManager.LoadScene("WinScene");
        }

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score--;
            scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
            if(score == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("EndScene");
            }
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PowerUp")
        {
            Debug.Log("Got Power up");
            PowerUpCount++;
            PowerUpCollectedText.GetComponent<Text>().text = "PowerUpCollected: " + PowerUpCount.ToString();
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("You Died");
            Destroy(other.gameObject);
            SceneManager.LoadScene("LoseScene");
        }
    }


   

}
