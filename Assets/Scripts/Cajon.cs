using UnityEngine;

public class Cajon : MonoBehaviour
{
    public float smooth;
    public float cuandoAbre;

    bool abierto;
    bool abriendo;
    bool cerrando;
    Vector3 posAbierto;
    Vector3 posCerrado;

    private void Start()
    {
        posCerrado = transform.localPosition;
        posAbierto = new Vector3(transform.localPosition.x - cuandoAbre, transform.localPosition.y, transform.localPosition.z);
    }

    private void Update()
    {
        if (abriendo) 
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posAbierto, smooth * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, posAbierto) < 0.0001f) 
            {
                abierto = true;
                abriendo = false;
            }
        }
        if (cerrando)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, posCerrado, smooth * Time.deltaTime);
            if (Vector3.Distance(transform.localPosition, posCerrado) < 0.0001f)
            {
                abierto = false;
                cerrando = false;
            }
        }
    }

    public void AbreCierra() 
    {
        if (!abierto) abriendo = true;
        else cerrando = true;
    }
}
