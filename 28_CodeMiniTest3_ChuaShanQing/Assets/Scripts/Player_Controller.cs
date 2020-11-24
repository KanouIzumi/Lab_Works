using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Animator PlayerAnim;
    public Rigidbody PlayerRb;
    public GameObject timerText;


    float moveSpeed = 5.0f;
    float JumpForce = 5.0f;
    float timerCount = 10.0f;
    int timeCountInt;
    bool IsOnPlane;

    //This is for the moving platform
    float platFormSpeed = 5.0f; //platform moving speed
    float zstart = 70.01f; // Platform limit on top
    float zLimit = 54.84f; // Platform limit at the bottom
    bool PlusLimit = true; // to check the moving platform condition

    bool MovingPlat = false;

    public GameObject MovingPlatform;
    public GameObject Bridge;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            StartRun();
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            PlayerAnim.SetBool("IsRun", false);
            PlayerAnim.SetFloat("StartRun", 0);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            StartRun();
        }

        else if (Input.GetKeyUp(KeyCode.S))
        {
            PlayerAnim.SetBool("IsRun", false);
            PlayerAnim.SetFloat("StartRun", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsOnPlane)
        {
            PlayerRb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            PlayerAnim.SetTrigger("TrigJump");
            IsOnPlane = false;
        }

        if (MovingPlat == true)
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
    }

    void StartRun()
    {
        PlayerAnim.SetBool("IsRun", true);
        PlayerAnim.SetFloat("StartRun", 3);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GamePlane"))
        {
            IsOnPlane = true;
            //This is to check if the character is on the floor
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            IsOnPlane = true;
        }

        if (collision.gameObject.CompareTag("Cone"))
        {
            Debug.Log("Activited Bridge");
           // GameObject.FindGameObjectWithTag("Bridge").transform.rotation = Quaternion.Euler(0, 0, 0);
            Bridge.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

   private void timerCountDown()
    {
        if(timerCount > 0 )
        {
            timerCount -= Time.deltaTime;
            timeCountInt = Mathf.RoundToInt(timerCount);
        }
        timerText.GetComponent<Text>().text = "Timer: " + timeCountInt;
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
}
