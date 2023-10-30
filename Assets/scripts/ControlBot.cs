using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBot : MonoBehaviour
{
    private int hp;
    private GameObject jugador;
    public int rapidez;
    public static int Kills;

    void Start()
    {
        hp = 100;
        jugador = GameObject.Find("Player");
    }
    private void Update()  //persecución al jugador
    {
        transform.LookAt(jugador.transform);
        transform.Translate(rapidez * Vector3.forward * Time.deltaTime);
    }
    public void recibirDaño()
    {
        hp = hp - 25; 
        if (hp <= 0)
        {
            this.desaparecer();
            Kills++;
            Debug.Log("Enemigos eliminados: " + Kills);
        }
    }
    void desaparecer()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            recibirDaño();
        }
    }
}
