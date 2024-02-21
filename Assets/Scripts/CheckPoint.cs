using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private int checkpointNumber;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision )
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SetCheckPoint(transform.position);
        }
    }
}
