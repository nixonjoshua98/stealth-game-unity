using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class LightController : MonoBehaviour
{
    Light2D globalLight;

    float timer = 0.0f;

    void Awake()
    {
        globalLight = GameObject.FindWithTag("Global Light").GetComponent<Light2D>();
    }

    void Update()
    {
        timer = Mathf.Max(0.0f, timer - Time.deltaTime);

        if (timer == 0.0f && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L)))
        {
            timer = 1.0f;

            globalLight.enabled = !globalLight.enabled;

            EventManager.OnLightToggle.Invoke(globalLight.enabled);
        }
    }
}
