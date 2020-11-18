using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControlle : MonoBehaviour
{
    public GameObject CoinCollectedText;
    public float speed;
    public float RotateSpeed;
    public float CoinCount;
    private int totalcount;
    private int CoinLeft;
    // Start is called before the first frame update
    void Start()
    {
        CoinCollectedText.GetComponent<Text>().text = "Start Function";
        CoinCollectedText.GetComponent<Text>().text = "Coin Collected: " + CoinCount.ToString();
        totalcount = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        CoinLeft = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Total Coin left is " + CoinLeft.ToString());
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
            transform.Rotate(new Vector3(0, Time.deltaTime * -RotateSpeed, 0));
            //transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // go right
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * RotateSpeed, 0));
            //transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (CoinCount == totalcount)
        {
            print("You Win!");
            SceneManager.LoadScene("WinScene");
        }

        if (transform.position.y < -5)
        {
            print("You Lose");
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            CoinCount++;
            CoinCollectedText.GetComponent<Text>().text = "Coin Collected: " + CoinCount.ToString();
            Destroy(other.gameObject);
        }
    }


}
