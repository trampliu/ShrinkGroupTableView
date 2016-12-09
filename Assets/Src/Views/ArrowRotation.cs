using UnityEngine;
using System.Collections;

public class ArrowRotation : MonoBehaviour {

    bool back = false;
    private void playRotation(object obj) {
        back = !back;
        if (back)
        {
            transform.Rotate(new Vector3(0, 0, 90));
        }
        else {
            transform.Rotate(new Vector3(0, 0, -90));
        }
    }

	// Use this for initialization
	void Start () {
        UIEventListener.Get(gameObject).onClick += playRotation;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
