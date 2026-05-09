using UnityEngine;
using UnityEngine.UI;

public class Planetas : MonoBehaviour
{
    [Header("Referencias de la Escena")]
    public GameObject esferaPlaneta;
    public Text txtPlaneta; 
    public AudioSource audioSource;

    [System.Serializable]
    public class DatosPlaneta
    {
        public string nombre;
        public Material material;
        public Vector3 escala;
        public AudioClip sonido;
    }

    [Header("Configuración de Planetas")]
    public DatosPlaneta[] listaDePlanetas;

    void Start()
    {
        esferaPlaneta.SetActive(false);
        txtPlaneta.text = "Selecciona un planeta";
    }


    public void SeleccionarPlaneta(int indice)
    {

        if (indice >= 0 && indice < listaDePlanetas.Length)
        {
            esferaPlaneta.SetActive(true);

            // 1. Aplicar Material
            esferaPlaneta.GetComponent<MeshRenderer>().material = listaDePlanetas[indice].material;

            // 2. Aplicar Escala
            esferaPlaneta.transform.localScale = listaDePlanetas[indice].escala;

            // 3. Cambiar Texto
            txtPlaneta.text = listaDePlanetas[indice].nombre;

            // 4. Reproducir Sonido
            if (listaDePlanetas[indice].sonido != null)
            {
                audioSource.Stop();
                audioSource.clip = listaDePlanetas[indice].sonido;
                audioSource.Play();
            }
        }
    }
}
