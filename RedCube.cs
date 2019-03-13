using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCube : MonoBehaviour
{
    public int k = 0;
    public float distantion;
    private float nextActionTime = 0.5f;
    public GameObject[] white;
    public GameObject[] color;
    public GameObject player;
    [Range(1.0f, 10.0f)]
    public float floatrange = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        white = GameObject.FindGameObjectsWithTag("default");
        color = GameObject.FindGameObjectsWithTag("living");
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime)
        {
            if (k >= 0)
            {
                float rx = Random.Range(-0.4F, 0.4F);
                float rz = Random.Range(-0.4F, 0.4F);
                transform.Translate(new Vector3(rx, 0, rz));
                nextActionTime += 0.5f;
                k++;
            }
        }
        for (int x = 0; x < color.Length; x++)
        {
            if (color[x].gameObject != null)
                if (Vector3.Distance(color[x].transform.position, transform.position) <= floatrange)
                {
                    k = -1;
                    transform.position = Vector3.MoveTowards(transform.position, color[x].transform.position, Time.deltaTime);
                }
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "living")
        {
            Destroy(collision.gameObject);
            k = 0;
        }
    }

}
