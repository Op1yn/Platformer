using UnityEngine;

public class InputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    private const string Jump = "Jump";
    private bool _isJump;

    public float Direction { get; private set; }

    private void Update()
    {
        Direction = Input.GetAxis(Horizontal);

        if (Input.GetAxis(Jump) > 0)
        {
            //Debug.Log("KeyCode.Space");
            _isJump = true;
        }
    }

    public bool GetIsJump()
    {
        //Debug.Log($"GetBoolAsTrigger {GetBoolAsTrigger(ref _isJump)}");

        return GetBoolAsTrigger(ref _isJump);
    }

    private bool GetBoolAsTrigger(ref bool value)
    {
        bool localValue = value;
        value = false;
        return localValue;
    }
}
