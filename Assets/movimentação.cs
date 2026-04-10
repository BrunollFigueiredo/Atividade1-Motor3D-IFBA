using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Sphere;

    void Start()
    {
        Cube = GameObject.Find("Cube");
        Sphere = GameObject.Find("Sphere");
    }

    void Update()
    {
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        float movimentoVertical = Input.GetAxis("Vertical");
        float velocidade = 5f;

        Vector3 cubePosition = Cube.transform.position;
        Vector3 cubeScale = Cube.transform.localScale; 

        Vector3 pos = transform.position;

        float limiteMinX = cubePosition.x - cubeScale.x / 2f;
        float limiteMaxX = cubePosition.x + cubeScale.x / 2f;
        float limiteMinZ = cubePosition.z - cubeScale.z / 2f;
        float limiteMaxZ = cubePosition.z + cubeScale.z / 2f;

        float novoX = Mathf.Clamp(pos.x + movimentoHorizontal * velocidade * Time.deltaTime, limiteMinX, limiteMaxX);
        float novoZ = Mathf.Clamp(pos.z + movimentoVertical * velocidade * Time.deltaTime, limiteMinZ, limiteMaxZ);

        transform.position = new Vector3(novoX, pos.y, novoZ);
    }
}