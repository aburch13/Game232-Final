using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFella : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(+.01f, 0);
    }
}
