using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery: MonoBehaviour
{
    [SerializeField] private bool _hasPackage;
    [SerializeField] private float _destroyCountdown = 0.5f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Color32 hasPackageColor;
    [SerializeField] private Color32 noPackageColor;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasPackage == false && other.tag == "Package")
        {
            _hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package Recieved");
            Destroy(other.gameObject, _destroyCountdown);            
        }

        if(_hasPackage == true && other.tag == "Customer")
        {
            _hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package Delivered");           
        }
    }
}
