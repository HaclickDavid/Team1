using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartTrigger : MonoBehaviour
{
    public Vector3 k = new Vector3(0,0);
    
    public HeartCount myHeartCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate((k - this.gameObject.transform.position) * Time.deltaTime );
    }
    public void HeartMove(Vector3 t){
        k=t;
    }
}
