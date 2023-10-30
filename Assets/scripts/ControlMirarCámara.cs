using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //script attached to the camera.
    Vector2 mouseMirar; 
    Vector2 suavidadV;

    public float sensibilidad = 0.5f;
    public float suavizado = 0.2f;

    GameObject jugador;
    void Start()
    {
        jugador = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, md.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, md.y, 1f / suavizado);

        mouseMirar += suavidadV; mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f);
        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
        jugador.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, jugador.transform.up);
    }
}
