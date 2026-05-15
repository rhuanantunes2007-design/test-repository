using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LixeiraController : MonoBehaviour
{
    public float velocity;

    // Modelos
    public GameObject modeloParado;
    public GameObject modeloAndando;

    // Start is called before the first frame update
    void Start()
    {
        // Começa parado
        modeloParado.SetActive(true);
        modeloAndando.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Movimento
        this.transform.position += new Vector3(horizontalInput * velocity * Time.deltaTime, 0, 0);

        // Troca de modelos
        if(horizontalInput > 0.3f || horizontalInput < -0.3f )
        {
            // Andando
            modeloParado.SetActive(false);
            modeloAndando.SetActive(true);
        }
        else
        {
            // Parado
            modeloParado.SetActive(true);
            modeloAndando.SetActive(false);
        }

        // Limite da tela
        if(this.transform.position.x > 10)
        {
            this.transform.position = new Vector3(
                10,
                this.transform.position.y,
                this.transform.position.z
            );
        }
        else if(this.transform.position.x < -10)
        {
            this.transform.position = new Vector3(
                -10,
                this.transform.position.y,
                this.transform.position.z
            );
        }
    }
}
