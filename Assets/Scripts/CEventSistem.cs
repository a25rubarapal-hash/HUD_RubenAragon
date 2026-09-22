using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CEventSistem : MonoBehaviour
{
    [SerializeField] private GameObject botonPorDefecto;
    private GameObject ultimoObjetoSeleccionado;

    void Start()
    {
        if (botonPorDefecto != null)
        {
            EventSystem.current.SetSelectedGameObject(botonPorDefecto);
            ultimoObjetoSeleccionado = botonPorDefecto;
        }
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (ultimoObjetoSeleccionado != null && ultimoObjetoSeleccionado.GetComponent<Button>().interactable)
            {
                EventSystem.current.SetSelectedGameObject(ultimoObjetoSeleccionado);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(botonPorDefecto);
            }
        }
        else
        {
            ultimoObjetoSeleccionado = EventSystem.current.currentSelectedGameObject;
        }
    }
}