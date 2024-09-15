using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    //public float animationSpeed = 1f;
    public Transform cameraTransform;
    public float parallaxFactor = 0.5f;
    public Rigidbody2D rigidbody2D;
    private Vector3 lastCameraPosition;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if(cameraTransform != null)
        {
            lastCameraPosition = cameraTransform.position;
        }
    }

    private void Update()
    {
        //meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
        if (cameraTransform != null && rigidbody2D != null)
        {
            float deltaX =  cameraTransform.position.x - lastCameraPosition.x;

            float offsetX = rigidbody2D.velocity.x * parallaxFactor * Time.deltaTime;

            transform.position = new Vector3(transform.position.x + offsetX, transform.position.y, transform.position.z);

            lastCameraPosition = cameraTransform.position;
        }
    }
}