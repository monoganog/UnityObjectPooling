using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Vector3 mousePosition;

    public Color[] colours;


    public GameObject physicsObject;
    public GameObject cursor;
    public float moveSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePos = Input.mousePosition;
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            cursor.transform.position = Vector2.Lerp(cursor.transform.position, mousePosition, moveSpeed);
        }

        if (Input.GetMouseButton(0))
        {
            InstantiateObject();
        }
    }

    private void InstantiateObject()
    {
        GameObject instance = Instantiate(physicsObject, mousePosition, Quaternion.identity);

        int randomColourIndex = Random.Range(0, colours.Length);
        Color colorChoice = colours[randomColourIndex];

        instance.GetComponent<SpriteRenderer>().color = colorChoice;
    }
}
