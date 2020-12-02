using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Animator PlayerAnim;
    public GameObject PowerUp;
    public GameObject EnergyCountText;
    public float EnergyCount;
    bool gameStart = true;

    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This code is for running
        if(GameManger_Controller.instance.levelTime < 0 || gameStart == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                StartRun();
            }
            else if (Input.GetKeyUp(KeyCode.W)) //Go up
            {
                PlayerAnim.SetBool("IsRun", false);
                PlayerAnim.SetFloat("StartRun", 0);
            }

            else if (Input.GetKey(KeyCode.S)) // Go back
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                StartRun();
            }

            else if (Input.GetKeyUp(KeyCode.S)) //Go Back
            {
                PlayerAnim.SetBool("IsRun", false);
                PlayerAnim.SetFloat("StartRun", 0);
            }

            else if (Input.GetKey(KeyCode.A)) // Go Left
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                StartRun();
            }


            else if (Input.GetKeyUp(KeyCode.A)) //Go Left
            {
                PlayerAnim.SetBool("IsRun", false);
                PlayerAnim.SetFloat("StartRun", 0);
            }

            else if (Input.GetKey(KeyCode.D)) // Go Right
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                StartRun();
            }


            else if (Input.GetKeyUp(KeyCode.D)) //Go Right
            {
                PlayerAnim.SetBool("IsRun", false);
                PlayerAnim.SetFloat("StartRun", 0);
            }
        }
        
        if (GameManger_Controller.instance.levelTime <= 0 || EnergyCount < 0)
        {
            SceneManager.LoadScene("LoseScene");
            gameStart = false;
        }
       
        if (EnergyCount >= 50 )
        {
            SceneManager.LoadScene("WinScene");
        }


    }


    void StartRun()
    {
        PlayerAnim.SetBool("IsRun", true);
        PlayerAnim.SetFloat("StartRun", 7);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AddEnergy"))
        {
            EnergyCount+=5;
            Destroy(collision.collider.gameObject);
            EnergyCountText.GetComponent<Text>().text = "EnergyCount: " + EnergyCount;
            GameManger_Controller.instance.RandomPopUp();
            GameManger_Controller.instance.levelTime += 3.0f;
        }

        if(collision.gameObject.CompareTag("MinusEnergy"))
        {
            EnergyCount -= 25;
            Destroy(collision.collider.gameObject);
            EnergyCountText.GetComponent<Text>().text = "EnergyCount: " + EnergyCount;
        }


        if (collision.gameObject.CompareTag("PowerUp"))
        {
            Destroy(GameObject.FindGameObjectWithTag("MinusEnergy"));
        }
    }
}
