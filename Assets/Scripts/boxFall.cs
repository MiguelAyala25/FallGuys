using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxFall : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    [SerializeField] private float fallTime;

    void Start()
    {
     rb=GetComponent<Rigidbody>();    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DropCube());
            Debug.Log("contact");
        }
    }
    IEnumerator DropCube()
    {
        yield return new WaitForSeconds(fallTime);
        rb.isKinematic = false;
    }
}
