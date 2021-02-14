using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Print");
        }
    }

    IEnumerator Print()
    {
        print("Ik start nu de coroutine");

        yield return new WaitForSeconds(0.5f);

        for (int i = 1; i <= 1; i++)
        {
            print("Coroutine Update" + " " + i);
        }

        yield return new WaitForSeconds(0.5f);

        print("Coroutine Einde");
    }
}
