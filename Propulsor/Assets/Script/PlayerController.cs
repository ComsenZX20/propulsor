using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;




public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    [SerializeField]
    float impulse = 2f;
    [SerializeField]
    TextMeshProUGUI labelFuel;
    // Start is called before the first frame update

    float gasolinaActual = 100f;

    [SerializeField]
    GameObject prefabParticles;
    void Start()
    {
        gasolinaActual = 100f;
        body = GetComponent<Rigidbody2D>();

    }
    //añadir fuerza a body hacia la derecha
    // Update is called once per frame
    // Update se ira gastando
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        gasolinaActual = gasolinaActual - 10f * Time.deltaTime;
        labelFuel.text = gasolinaActual.ToString("00.00") + "%";
        //para que se mueva usando wasd/flechas o con mando
        //y = Input.GetAxis


        //si la gasolina acaba
        //desactivar componente

        //si gasolina 0 o menos
        if(gasolinaActual <= 0f)
        { 
            this.enabled = false;
            labelFuel.text = "0 %";
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fuel" && gasolinaActual > 0.0f)

            gasolinaActual = gasolinaActual += 10f;

        if (gasolinaActual > 100f)
        {
            gasolinaActual = 100f;

        }



        //Crear Particulas
        Instantiate(prefabParticles, collision.transform.position, collision.transform.rotation);
        //Destruir
        Destroy(collision.gameObject);

    }
    
    private void FixedUpdate()
    {
        body.AddForce(direction, ForceMode2D.Impulse);
        

    }
    
}  
