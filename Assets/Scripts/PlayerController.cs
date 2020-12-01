using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    public static float MOVE_SPEED = 3.0f;

    [Header("Components")]
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sr;

    void Update()
    {
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
}
