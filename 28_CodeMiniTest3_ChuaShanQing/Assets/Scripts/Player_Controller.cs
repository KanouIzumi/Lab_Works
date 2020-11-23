using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

}
