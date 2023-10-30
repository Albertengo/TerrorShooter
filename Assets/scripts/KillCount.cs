using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace interfaz
{
    public class KillCount : MonoBehaviour
    {
        public TextMeshProUGUI Contador;
        void Start()
        {
            Contador = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            Contador.text = ControlBot.Kills + "/8 asesinatos";
        }
    }
}
