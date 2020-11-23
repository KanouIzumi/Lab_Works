using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge_Controller : MonoBehaviour
{
    public GameObject Cone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Activited Bridge");
            //GameObject.FindGameObjectWithTag("Bridge").transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
