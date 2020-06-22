using UnityEngine;

public class CameraBorders : MonoBehaviour {

    public bool leftBorder;
    public bool rightBorder;

    private float leftLimitation;
    private float rightLimitation;

    private void Start()
    {
        float dist = (transform.position.z - Camera.main.transform.position.z);

        if(leftBorder)
        {
            leftLimitation = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
            transform.position = new Vector3(leftLimitation, 0, 0);
        }
            
        if(rightBorder)
        {
            rightLimitation = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
            transform.position = new Vector3(rightLimitation, 0, 0);
        }
    }
}
