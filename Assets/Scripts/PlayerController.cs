using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public static float MOVE_SPEED = 3.5f;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;

    Light2D globalLight;

    void Awake()
    {
        globalLight = GameObject.FindWithTag("Global Light").GetComponent<Light2D>();
    }

    void Update()
    {
        CheckInput();

        Move();
    }

    void Move()
    {
        Vector2 moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        anim.SetFloat("MoveX", moveVector.x);
        anim.SetFloat("MoveY", moveVector.y);

        rb2d.MovePosition(rb2d.position + (moveVector * MOVE_SPEED * Time.deltaTime));

        sr.flipX = moveVector.x > 0;
    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.L))
        {
            globalLight.enabled = !globalLight.enabled;

            EventManager.OnLightToggle.Invoke(globalLight.enabled);
        }
    }
}
