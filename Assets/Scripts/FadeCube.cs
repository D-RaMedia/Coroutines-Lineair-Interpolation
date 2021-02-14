using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCube : MonoBehaviour
{
    public float fadeTime;
    Material material;
    bool Press = false;
    bool cubeIsVisible;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        if (material.color.a == 0)
        {
            cubeIsVisible = false;
        }
        else
        {
            cubeIsVisible = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Press == false)
            {
                Press = true;
                StartCoroutine("Fade");
            }
        }
    }

    IEnumerator Fade()
    {
        if (cubeIsVisible == true)
        {
            for (float i = material.color.a; i > 0f; i -= 0.1f)
            {
                material.color = new Color(1f, 1f, 1f, i);
                print(i);
                yield return new WaitForSeconds(fadeTime);
            }
            material.color = new Color(1f, 1f, 1f, 0f);
            cubeIsVisible = false;
        }
        else if (cubeIsVisible == false)
        {
            for (float i = material.color.a; i < 1f; i += 0.1f)
            {
                material.color = new Color(1f, 1f, 1f, i);
                print(i);
                yield return new WaitForSeconds(fadeTime);
            }
            material.color = new Color(1f, 1f, 1f, 1f);
            cubeIsVisible = true;
        }
        Press = false;
    }
}
