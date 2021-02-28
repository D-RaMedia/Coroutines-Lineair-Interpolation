using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdr1 : MonoBehaviour
{
    public Transform start;
    public Transform end;
    private float startTime;
    private float speed = 1f;
    private float journeyLength;
    private float test;
    private void Start()
    {
        this.transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            startTime = Time.time;
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        journeyLength = Vector3.Distance(start.position, end.position);
        for (float i = start.position.x; i <= 1f; i = test)
        {
            float distance = (Time.time - startTime) * speed;
            test = distance / journeyLength;
            this.transform.position = Vector3.Lerp(start.position, end.position, test);
            yield return 0;
        }
    }
}
