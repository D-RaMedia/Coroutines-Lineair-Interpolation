using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform StartMove;
    public Transform EndMove;

    private float startTime;
    private float speed = 2.5f;
    private float journeyLength;
    private float testSpin;
    private void Start()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startTime = Time.time;
            StartCoroutine("MoveOfCube");
        }
    }

    IEnumerator MoveOfCube()
    {
        journeyLength = Vector3.Distance(StartMove.position, EndMove.position);
        for (float i = StartMove.position.x; i <= 1f; i = testSpin)
        {
            float distCovered = (Time.time - startTime) * speed;
            testSpin = distCovered / journeyLength;
            this.transform.position = Vector3.Lerp(StartMove.position, EndMove.position, testSpin);
            yield return 0;
        }
    }
}
