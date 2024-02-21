using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public float timer = 0;
    public int checkPoint { get; private set; }
    public Vector3 lastCheckPointPos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        timer=timer+Time.deltaTime;
    }
    public void SetCheckPoint(Vector3 newCheckPointPos)
    {
        lastCheckPointPos = newCheckPointPos;
    }
}
