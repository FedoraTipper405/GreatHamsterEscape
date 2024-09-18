using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    //public float animationSpeed = 1f;
    public Camera camera;
    public float parallaxFactor = 0.5f;
    public Rigidbody2D rigidbody2D;
    private Vector3 lastCameraPosition;
    [SerializeField]
    float offsetForFix;
    private void Awake()
    {
        camera = Camera.main;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        if(camera != null)
        {
            
        }
    }

    private void Update()
    {


        if (camera != null && rigidbody2D != null)
        {
            Vector3 camPos = camera.transform.position;
            float x = camPos.x;
            Vector3 newPos = new Vector3(camPos.x, transform.position.y, transform.position.z);

            transform.position = newPos;

            float offsetX = rigidbody2D.velocity.x * parallaxFactor * Time.deltaTime;
        meshRenderer.material.mainTextureOffset += new Vector2(offsetX,0);

            transform.position = new Vector3(transform.position.x + offsetX + offsetForFix, transform.position.y, transform.position.z);

           // lastCameraPosition = camera.position;
        }
    }
}