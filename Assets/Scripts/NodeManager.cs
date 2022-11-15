using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : MonoBehaviour
{
	private readonly System.Random _random = new System.Random();
    public Node[] nodes = new Node[6];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nodes.Length; i++) {
            nodes[i].id = i;
        }

        RunSimulation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunSimulation() {
        for (int i = 0; i < nodes.Length; i++) {
            if (i != 0) nodes[i - 1].selected = false;

            nodes[i].selected = true;

            for (int k = 0; k < nodes.Length; k++) {
                if (k != nodes[i].id && _random.Next(0, 2) == 0) {
                    if (!nodes[i].knownNodes.Contains(nodes[k])) {
                        nodes[i].knownNodes.Add(nodes[k]);
                    }
                    if (!nodes[k].knownNodes.Contains(nodes[i])) {
                        nodes[k].knownNodes.Add(nodes[i]);
                    }
                }
            }
            
            nodes[i].SetupFlashlight();
        }
    }

    void ResetSimulation() {
        for (int i = 0; i < nodes.Length; i++) {
            if (i != 0) nodes[i - 1].selected = false;

            nodes[i].selected = true;
            nodes[i].ResetNode();
        }
    }
}
