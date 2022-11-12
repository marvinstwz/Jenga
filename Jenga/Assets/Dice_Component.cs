using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice_Component : MonoBehaviour
{
    // Script que se encarga de funcionamiento aleatorio del dado, al clickear el jugador, se coloca en la posicion inicial
    // con una rotacion y fuerza aleatoria

    [SerializeField]
    private Vector3 InitialPos;

    private Rigidbody _rb;

    [SerializeField]
    private float[] DiceSpeedRange;

    private int RandomRotation => Random.Range(0, 361);

    [SerializeField]
    private GameObject _diceObject;

    private void Awake()
    {
        InitialPos = transform.position;
        _rb = _diceObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            DoDiceRoll();
        }
    }

    private void DoDiceRoll()
    {
        _diceObject.transform.localPosition = Vector3.zero;
        _diceObject.transform.rotation = Quaternion.Euler(new Vector3(RandomRotation, RandomRotation, RandomRotation)); 

        _rb.AddForce(new Vector3(0, Random.Range(DiceSpeedRange[0], DiceSpeedRange[1]), 0));
    }
}
