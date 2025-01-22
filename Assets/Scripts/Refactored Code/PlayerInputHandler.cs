using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3 GetInput(KeyCode forwardKey, KeyCode backwardKey, KeyCode leftKey, KeyCode rightKey)
    {
        float xInput = 0;
        float zInput = 0;

        if (Input.GetKey(forwardKey)) zInput++;
        else if (Input.GetKey(backwardKey)) zInput--;
        if (Input.GetKey(leftKey)) xInput--;
        else if (Input.GetKey(rightKey)) xInput++;

        return new Vector3(xInput, 0, zInput);
    }
}
