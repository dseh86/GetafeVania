using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarcianoScript : MonoBehaviour {

    [SerializeField] int vidas;
    [SerializeField] int puntuacion;
    [SerializeField] LayerMask floorLayer;
    [SerializeField] Transform posPies;
    [SerializeField] Text txtPuntuacion;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float radioOverlap = 0.1f;
    Rigidbody2D rb2D;
    int vidasMaximas = 5;
    bool saltando = true;
    bool enSuelo;



    public void incrementarPuntuacion(int puntuacion) {


    }

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        txtPuntuacion.text = "Score: " + puntuacion;


    }

    private bool EstaEnSuelo() {
        bool enSuelo = false;
        Collider2D col = Physics2D.OverlapCircle(posPies.position, radioOverlap, floorLayer);
        if (col != null) {

            enSuelo = true;
        }

        return enSuelo;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            saltando = true;
        }

    }
    private void FixedUpdate() {

        float xPos=Input.GetAxis("Vertical");
        float yPos=Input.GetAxis("Horizontal");
        float ySpeedActual = rb2D.velocity.y;


        if (Input.GetKeyDown(KeyCode.Space)) {
            if (EstaEnSuelo()) {
                rb2D.velocity = new Vector3(xPos * speed, jumpForce);
            }

        }
    }

    
}
