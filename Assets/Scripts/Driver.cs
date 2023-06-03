using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 0.01f;

    private bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Uper" && hasPackage == false)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, 0.5f);
        }
        if (other.tag == "Customer")
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Destroy(other.gameObject, 0.5f);
        }
    }
}
