using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour
{
    public LayerMask groundLayer;
    private XROrigin rig;
    public XRNode inputSource;
    private Vector2 inputAxis;
    private CharacterController character;
    [SerializeField]
    private float speed = 1f;
    private float gravity = 9.8f;
    private float fallingSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<XROrigin>();
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }
    private void FixedUpdate()
    {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector3 direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * speed * Time.deltaTime);

        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
        }
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    private bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
