using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(190, 70, 70, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
    [SerializeField] float packageDestroyDelaySec = 0.5f;

    SpriteRenderer spriteRenderer;
    bool hasPackage = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");

            hasPackage = true;
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, packageDestroyDelaySec);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");

            hasPackage = false;

            spriteRenderer.color = noPackageColor;
        }
    }
}
