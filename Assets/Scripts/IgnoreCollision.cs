using UnityEngine;

public class IgnoreCollii : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (GameObject.Find ("npc1") != null) Physics2D.IgnoreCollision (GetComponent<BoxCollider2D>(), GameObject.Find ("npc1").GetComponent<PolygonCollider2D> ());
        int layer1 = GameObject.Find ("npc1").layer;
        int layer2 = gameObject.layer;
        Physics2D.IgnoreLayerCollision(layer1, layer2, true);
    }
    // Update is called once per frame
        void Update()
    {
        
    }
}
