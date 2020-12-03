using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManger_Controller : MonoBehaviour
{
    public static GameManger_Controller instance;
    public GameObject[] EnergyCubes;
    public GameObject TimeLimit;
    public int numberOfSpawns;
    public float levelTime;
    public int iTotalMinusSize;
    public int iTotalAddSize;
    public int iRemovedAddCount;
    public int iMinusNow;

    List<GameObject> addCubeGOs = new List<GameObject>();
    List<GameObject> minusCubeGOs = new List<GameObject>();

    int iRandomEnergyCubes;
    float maxLimit = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        //This code is for the random spawn
        //int ISize = 10;
        int ISize = Random.Range(5,11);

        while (ISize > 0)
        {
            iRandomEnergyCubes = Random.Range(0, EnergyCubes.Length);

            Vector3 newPos = new Vector3(Random.Range(-maxLimit, maxLimit), transform.position.y, Random.Range(-maxLimit, maxLimit));

            if(iRandomEnergyCubes ==0)
            {
                addCubeGOs.Add(Instantiate(EnergyCubes[iRandomEnergyCubes], newPos, Quaternion.identity));
            }
            else
            {
                minusCubeGOs.Add(Instantiate(EnergyCubes[iRandomEnergyCubes], newPos, Quaternion.identity));
            }

            ISize--;
        }
        iTotalMinusSize = minusCubeGOs.Count;
        iTotalAddSize = addCubeGOs.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTime > 0)
        {
            levelTime -= Time.deltaTime;
           // print("LevelTime: " + FormatTime(levelTime));
            TimeLimit.GetComponent<Text>().text = "LevelTime: " + FormatTime(levelTime);
        }
        else
        {
            levelTime = 0;
            TimeLimit.GetComponent<Text>().text = "LevelTime: 00:00:000";
            print("Times Up!");
        }


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(GameObject.FindGameObjectWithTag("MinusEnergy"));
        }

    }

    public string FormatTime(float time)
    {
        int minutes = (int)time / 60;
        int seconds = (int)time - 60 * minutes;
        int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
        return string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, milliseconds);
        
    }

    public void RandomPopUp()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {

            iRandomEnergyCubes = Random.Range(0, EnergyCubes.Length);

            Vector3 newPos = new Vector3(Random.Range(-maxLimit, maxLimit), transform.position.y, Random.Range(-maxLimit, maxLimit));

            Instantiate(EnergyCubes[iRandomEnergyCubes], newPos, Quaternion.identity);

        }
    }


    public void DestroyMinusCube()
    {
        while (iTotalMinusSize > iMinusNow)
        {
            Destroy(minusCubeGOs[iMinusNow]);
            iMinusNow++;
        }
    }
}
