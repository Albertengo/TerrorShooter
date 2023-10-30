using interfaz;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{
    #region Variables
    public GameObject jugador;
    public GameObject bot;
    public Win_Lose screenW;
    public Win_Lose screenL;
    public static float tiempoRestante;
    public int xPos;
    public int zPos;
    public static int CantidadEnemigos;
    #endregion

    #region voids basicos
    void Start()
    {
        ComenzarJuego();
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoRestante == 0)
        {
            ComenzarJuego();
            screenL.ActiveScreen();
        }
        if (ControlBot.Kills == 8)
        {
            screenW.ActiveScreen();
        }
    }
    #endregion

    #region Code
    void ComenzarJuego()
    {
        jugador.transform.position = new Vector3(0f, 1.07f, 0f);
        StartCoroutine(SpawnEnemigos());
        StartCoroutine(Cronometro(30));
    }
    IEnumerator SpawnEnemigos()
    {
        while (CantidadEnemigos < 8)
        {
            xPos = Random.Range(1, 10);
            zPos = Random.Range(1, 10);
            Instantiate(bot, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            CantidadEnemigos += 1;
        }
    }
    public IEnumerator Cronometro(float valorCronometro = 30)
    {
        tiempoRestante = valorCronometro;
        while (tiempoRestante > 0)
        {
            yield return new WaitForSeconds(1.0f);
            tiempoRestante--;
        }
    }
    #endregion
}
