using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;
    public bool selected = false;

    public int id = 0;
    public List<Node> knownNodes = new List<Node>();

    public List<Transform> flashlights = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected) {
            gameObject.GetComponent<Renderer>().material = selectedMaterial;
        } else {
            gameObject.GetComponent<Renderer>().material = defaultMaterial;
        }
    }

    public void SetupFlashlight() {
        knownNodes.ForEach(knownNode => {
            transform.GetChild(knownNode.id).gameObject.SetActive(true);
            transform.GetChild(knownNode.id).LookAt(knownNode.transform);

            flashlights.Add(transform.GetChild(knownNode.id));
        });
    }

    public void ResetNode() {
        selected = false;
        knownNodes = new List<Node>();
        flashlights = new List<Transform>();
    }
}
