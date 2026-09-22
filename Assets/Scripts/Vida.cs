using UnityEngine;

public class Vida : MonoBehaviour
{
    private int vidaMaxima = 3;
    private int vidaActual;

    public int GetVidaMaxima()
    {
        return vidaMaxima;
    }

    public void SetVidaMaxima(int valor)
    {
        vidaMaxima = valor;
    }

    public int GetVidaActual()
    {
        return vidaActual;
    }

    public void SetVidaActual(int valor)
    {
        vidaActual = valor;
    }

    void Start()
    {
        SetVidaActual(GetVidaMaxima());
    }

    public bool EstaVivo()
    {
        return GetVidaActual() > 0;
    }

    public bool EstaMuerto()
    {
        return GetVidaActual() <= 0;
    }

    public void QuitarVida()
    {
        if (EstaVivo())
            SetVidaActual(GetVidaActual() - 1);
    }

    public void Curar()
    {
        if (EstaVivo() && GetVidaActual() < GetVidaMaxima())
            SetVidaActual(GetVidaActual() + 1);
    }

    public void Matar()
    {
        if (EstaVivo())
            SetVidaActual(0);
    }

    public void Revivir()
    {
        if (EstaMuerto())
            SetVidaActual(GetVidaMaxima());
    }
}