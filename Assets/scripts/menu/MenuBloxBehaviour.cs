using UnityEngine;
using TMPro;

public class MenuBloxBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    float rotationValue = 0f;
    BloxSpawner parent;
    TextMeshPro textChild;

    void Start()
    {
        textChild = GetComponentInChildren<TextMeshPro>();
        parent = transform.parent.GetComponent<BloxSpawner>();
        rb = GetComponent<Rigidbody2D>(); 
        rotationValue = Random.Range(-1f, 1f);

        float startingGravity = Random.Range(0.05f, 0.1f);
        rb.gravityScale = startingGravity;

        int randomIndex = Random.Range(0, parent.Keywords.Count);
        textChild.text = parent.Keywords[randomIndex];
    }

    void OnTriggerEnter2D(Collider2D other){
        Destroy(gameObject);
    }

    void FixedUpdate(){
        rb.rotation += rotationValue;
    }
}
