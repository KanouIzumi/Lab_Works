using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Animator PlayerAnim;
    public Rigidbody PlayerRb;
    public GameObject timerTextGO;
    public GameObject Child;
    public Material[] playermtrls;


    float moveSpeed = 5.0f;
    float JumpForce = 5.0f;
    bool IsOnPlane;

    //This is for the moving platform
    float platFormSpeed = 5.0f; //platform moving speed
    float zstart = 70.01f; // Platform limit on top
    float zLimit = 54.84f; // Platform limit at the bottom
    bool PlusLimit = true; // to check the moving platform condition

    bool MovingPlat = false;

    public GameObject MovingPlatform;
    public GameObject Bridge;
    public GameObject PowerUp;


    //This is for the power up
    public int PowerUpCount;
    private int TotalPowerUp;

    //This is for the timer
    int timeCountInt;
    float timerCount = 10;
    bool isStartCount;

    // Start is called before the first frame update
    void Start()
    {
        TotalPowerUp = GameObject.FindGameObjectsWithTag("PowerUp").Length;
        Child.GetComponent<SkinnedMeshRenderer>().material.color = playermtrls[0].color;
    }

    // Update is called once per frame
    void Update()
    {

        //This code is for running
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

        if (Input.GetKeyDown(KeyCode.Space) && IsOnPlane) // This code is for Jumping
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            PlayerAnim.SetTrigger("TrigJump");
            Child.GetComponent<SkinnedMeshRenderer>().material.color = playermtrls[1].color;
            IsOnPlane = false;
        }

        if (transform.position.y < -5)
        {
            print("You Lose");
            SceneManager.LoadScene("GameOverScene");
        }



        if (MovingPlat == true) // The moving platform will start to move
        {
            if (MovingPlatform.transform.position.z < zstart && PlusLimit == true)
            {
                MovingPlatform.transform.Translate(Vector3.forward * Time.deltaTime * platFormSpeed);

            }
            else if (MovingPlatform.transform.position.z > zLimit && PlusLimit == false)
            {
                MovingPlatform.transform.Translate(Vector3.forward * Time.deltaTime * -platFormSpeed);
            }
            else
            {
                PlusLimit = !PlusLimit; //Changing PlusLimit into false
            }



        }

        if (isStartCount == true)
        {
            timerCountDown();
        }
    }

    void StartRun()
    {
        PlayerAnim.SetBool("IsRun", true);
        PlayerAnim.SetFloat("StartRun", 3);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // collision.gameObject
        // this.gameObject 
        if (collision.gameObject.CompareTag("GamePlane"))
        {
            IsOnPlane = true;
            Child.GetComponent<SkinnedMeshRenderer>().material.color = playermtrls[0].color;
            //This is to check if the character is on the floor

        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            IsOnPlane = true;
            Child.GetComponent<SkinnedMeshRenderer>().material.color = playermtrls[0].color;
        }

        if (collision.gameObject.CompareTag("PowerUp"))
        {
            PowerUpCount++;
            print("Got Power Up");
            Destroy(collision.gameObject);
            // gameObject -> Player gameObject
            // collision.gameObject -> the other gameobject
        }

        if (PowerUpCount == TotalPowerUp)
        {
            if (collision.gameObject.CompareTag("Cone"))
            {
                Debug.Log("Activited Bridge");
                // GameObject.FindGameObjectWithTag("Bridge").transform.rotation = Quaternion.Euler(0, 0, 0);
                Bridge.transform.rotation = Quaternion.Euler(0, 0, 0);

                isStartCount = true;
            }
        }

        if (collision.gameObject.CompareTag("Bridge"))
        {
            IsOnPlane = true;
            Child.GetComponent<SkinnedMeshRenderer>().material.color = playermtrls[0].color;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            Debug.Log("Actived Moving Platform");
            MovingPlat = true;
            //Debug.Log("Hello");
        }
    }

    private void timerCountDown()
    {
        if (timerCount > 0)
        {
            timerCount -= Time.deltaTime;
            timeCountInt = Mathf.RoundToInt(timerCount);
            timerTextGO.GetComponent<Text>().text = "Timer: " + timeCountInt;
        }

        else if (timerCount < 1)
        {
            timerCount = 10.0f;
            Bridge.transform.rotation = Quaternion.Euler(0, 90, 0);
            isStartCount = false;
        }

    }

}
