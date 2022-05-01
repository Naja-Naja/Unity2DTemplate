using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    public bool _isGround;
    [SerializeField] BoxCollider2D boxCollider2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGround = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        _isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isGround = false;
    }
}
