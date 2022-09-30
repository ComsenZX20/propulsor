using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    float impulse = 2f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
       
    }
    //añadir fuerza a body hacia la derecha
    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;
        //para que se mueva usando wasd/flechas o con mando
        //y = Input.GetAxis
    }

    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);

    }
}
