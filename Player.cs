
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    private Rigidbody2D rb2D;
    private Animator animator;
    private bool eLadoDireito;
    // Start is called before the first frame update
    [SerializeField]
    public float velocidade = 6;
    //Variavels
    float horizontal;
    void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        eLadoDireito = transform.localScale.x > 0;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        horizontal = Input.GetAxis("Horizontal");

        Movimentar(horizontal);
        MudarDirecao(horizontal);
    }
    private void Movimentar(float h)
    {
        // h*velocidade
        rb2D.velocity = new Vector2(h*velocidade,rb2D.velocity.y);
        animator.SetFloat("velocity", Mathf.Abs(h));
        Debug.Log(Vector2.right);
    }
    private void MudarDirecao(float horizontal)
    {
        if (horizontal > 0 && !eLadoDireito || horizontal < 0 && eLadoDireito)
        {
            eLadoDireito = !eLadoDireito;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}