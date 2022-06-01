using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float destroyDelay;
    private bool hasPackage;
    
    [Header("Colors")]
    [SerializeField] private Color32 hasPackageColor = new Color32(255,0,222, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1,1,1, 1);

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package Aquired");
            
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
        
    }
}
