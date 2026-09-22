using UnityEngine;
using UnityEngine.UI;

public class VidaHud : MonoBehaviour
{
    [SerializeField] private Vida vidaJugador;
    [SerializeField] private RawImage[] contenedoresCorazon;
    [SerializeField] private Texture texturaCorazonLleno;
    [SerializeField] private Texture texturaCorazonVacio;
    [SerializeField] private Button btnQuitarVida;
    [SerializeField] private Button btnCurar;
    [SerializeField] private Button btnMatar;
    [SerializeField] private Button btnRevivir;

    private int ultimaVidaConocida = -1;

    void Update()
    {
        if (vidaJugador.GetVidaActual() != ultimaVidaConocida)
        {
            ActualizarVisuales(vidaJugador.GetVidaActual());
            ActualizarEstadoBotones();

            ultimaVidaConocida = vidaJugador.GetVidaActual();
        }
    }

    private void ActualizarVisuales(int vidaActual)
    {
        for (int i = 0; i < contenedoresCorazon.Length; i++)
        {
            if (i < vidaActual)
                contenedoresCorazon[i].texture = texturaCorazonLleno;
            else
                contenedoresCorazon[i].texture = texturaCorazonVacio;
        }
    }

    private void ActualizarEstadoBotones()
    {
        bool estaVivo = vidaJugador.EstaVivo();
        bool estaMuerto = vidaJugador.EstaMuerto();
        bool vidaLlena = vidaJugador.GetVidaActual() == vidaJugador.GetVidaMaxima();

        btnMatar.interactable = estaVivo;
        btnRevivir.interactable = estaMuerto;

        btnQuitarVida.interactable = estaVivo;
        btnCurar.interactable = (estaVivo && !vidaLlena);
    }
}