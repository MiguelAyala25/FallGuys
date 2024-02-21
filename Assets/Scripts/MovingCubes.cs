using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovingCubes : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes = new List<GameObject>();
    [SerializeField] private float delayBetweenMoves = 5f;

    private float timer = 0;
    private float moveHeight = 5f;
    private float moveSpeed = 2f;

    private float checkDistance = 0.1f;

    [SerializeField] private int seed = 0; 
    private System.Random randomGenerator;
    void Start()
    {
        randomGenerator = new System.Random(seed);
        timer = delayBetweenMoves;

    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int randomNumber = randomGenerator.Next(0, cubes.Count);

            if (IsGrounded(cubes[randomNumber]))
            {
                StartCoroutine(MoveCube(randomNumber));
            }


            timer = delayBetweenMoves;
        }
    }

    IEnumerator MoveCube(int cubeIndex)
    {
        GameObject selectedCube = cubes[cubeIndex];
        float targetYPosition = selectedCube.transform.position.y + moveHeight;

        //moves cube up
        while (selectedCube.transform.position.y < targetYPosition)
        {
            selectedCube.transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            yield return null;
        }
        //wait one second in the air
        yield return new WaitForSeconds(1);

        // Move cube back
        while (selectedCube.transform.position.y > targetYPosition - moveHeight)
        {
            selectedCube.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
    private bool IsGrounded(GameObject cube)
    {
        RaycastHit hit;

        if (Physics.Raycast(cube.transform.position, Vector3.down, out hit, cube.transform.localScale.y / 2 + checkDistance))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }
}
