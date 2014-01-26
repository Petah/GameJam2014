using UnityEngine;
using System.Collections;

public class Impact {
    
    public GameObject from;
    public bool swing;

    public Impact(GameObject from, bool swing) {
        this.from = from;
        this.swing = swing;
    }

}
