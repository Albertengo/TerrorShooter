using UnityEngine;

namespace Player
{
    public class ControlPlayer : MonoBehaviour
    {
        //script attached to the player

        public float rapidezDesplazamiento = 10.0f;
        public float modificadorSprint;
        [SerializeField] Rigidbody rb;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            rb = GetComponent<Rigidbody>();
        }
        
        void FixedUpdate()
        {
            float movimientoAdelanteAtras = Input.GetAxis("Vertical"); //* modificadorSprint;
            float movimientoCostados = Input.GetAxis("Horizontal"); //* modificadorSprint; //antes estaba la rapidez de desplazamiento

            //movimientoAdelanteAtras *= Time.deltaTime;
            //movimientoCostados *= Time.deltaTime;

            bool correr = Input.GetKey(KeyCode.LeftShift);
            bool esta_corriendo = correr && movimientoAdelanteAtras > 0;

            //transform.Translate(movimientoCostados, 0, movimientoAdelanteAtras);
            Vector3 direccion = new Vector3(movimientoCostados, 0, movimientoAdelanteAtras);
            direccion.Normalize();

            float speedsprint = rapidezDesplazamiento;

            if (esta_corriendo) speedsprint *= modificadorSprint;
            rb.velocity = transform.TransformDirection(direccion) * speedsprint * Time.deltaTime;

            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }

        }

        
    }
}
