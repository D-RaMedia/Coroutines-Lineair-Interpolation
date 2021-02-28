using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opdr2 : MonoBehaviour
{
    Material material;

    public Vector3 endPos;
    public Vector3 endScale;

    private Vector3 _startPos;
    private Vector3 _startScale;

    public float moveTime;
    public float fadeTime;
    private float _percent;
    private float _easeStep;

    public bool move;
    public bool grow;
    public bool easeInQuad;
    public bool easeOutQuad;
    public bool easeOutQuart;
    public bool cubeIsVisible;

    public bool Press = false;

    private void Start()
    {

        _startScale = transform.localScale;
        _startPos = transform.position;
        _percent = 0;

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
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(EaseIn());
        }
    }

    private IEnumerator EaseIn()
    {
        while (_percent < 1)
        {
            _percent += Time.deltaTime / moveTime;

            if (easeInQuad)
            {
                _easeStep = _percent * _percent;
            }
            else if (easeOutQuad)
            {
                float sum = 1 - _percent;
                _easeStep = 1 - sum * sum;
            }
            else if (easeOutQuart)
            {
                float pow = Mathf.Pow(1 - _percent, 4);
                _easeStep = 1 - pow;
            }

            if (move)
            {
                Vector3 distance = endPos - _startPos;
                Vector3 travelDistance = distance * _easeStep;
                Vector3 newPos = _startPos + travelDistance;
                transform.position = newPos;
            }

            if (grow)
            {
                Vector3 scale = endScale - _startScale;
                Vector3 scaleIncrease = scale * _easeStep;
                Vector3 newScale = _startScale + scaleIncrease;
                transform.localScale = newScale;
            }

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

            yield return null;
        }
    }
}
