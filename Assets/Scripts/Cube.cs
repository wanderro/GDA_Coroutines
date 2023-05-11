using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private Material _cubeMaterial;
    private Color _newColor;
    [SerializeField] private float colorChangeSpeed = 1f;
    private void Awake()
    {
        _cubeMaterial = GetComponent<Renderer>().material;
        _newColor = _cubeMaterial.color;
    }

    private void Update()
    {
        _cubeMaterial.color = Color.Lerp(_cubeMaterial.color, _newColor, colorChangeSpeed * Time.deltaTime);
    }

    public void ChangeColor(Color newColor)
    {
        _newColor = newColor;
    }
}
