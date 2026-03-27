using UnityEngine;

public class movimentação : MonoBehaviour
{
    public GameObject Cube;

    public GameObject Sphere;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()

    {

        Cube = GameObject.Find("Cube");

        Sphere = GameObject.Find("Sphere");

    }



    // Update is called once per frame

    void Update()

    {



        float movimentoHorizontal = Input.GetAxis("Horizontal");

        float movimentoVertical = Input.GetAxis("Vertical");

        Debug.Log("Valor horizontal: " + movimentoHorizontal.ToString());

        Debug.Log("Valor Vertical: " + movimentoVertical.ToString());

        float velocidade = 5f;

        

        Vector3 playerPosition = Sphere.transform.position;

        Vector3 cubePosition = Cube.transform.position;

        Vector3 cubeScale = Cube.transform.localScale;

        Debug.Log("Position Player: " + playerPosition);

        Debug.Log("Position Cube: " + cubePosition);

        Debug.Log("Scale Cube: " + cubeScale);// valor e posição como calcular??????

        float limiteMinX = cubePosition.x - (cubeScale.x / 2f);
        float limiteMaxX = cubePosition.x + (cubeScale.x / 2f);
        float limiteMinZ = cubePosition.z - (cubeScale.z / 2f);
        float limiteMaxZ = cubePosition.z + (cubeScale.z / 2f);

       
        float centroMinX = cubePosition.x - 1.5f;
        float centroMaxX = cubePosition.x + 1.5f;
        float centroMinZ = cubePosition.z - 1.5f;
        float centroMaxZ = cubePosition.z + 1.5f;

        float proximoX = playerPosition.x + (movimentoHorizontal * velocidade * Time.deltaTime);

        
        float proximoZ = playerPosition.z + (movimentoVertical * velocidade * Time.deltaTime);


        if (proximoX >= limiteMinX && proximoX <= limiteMaxX &&
            !(proximoX >= centroMinX && proximoX <= centroMaxX &&
              playerPosition.z >= centroMinZ && playerPosition.z <= centroMaxZ))
        {
            Vector3 mover = new Vector3(movimentoHorizontal, 0f, 0f);
            transform.Translate(mover * velocidade * Time.deltaTime);
        }

      
        if (proximoZ >= limiteMinZ && proximoZ <= limiteMaxZ &&
            !(playerPosition.x >= centroMinX && playerPosition.x <= centroMaxX &&
              proximoZ >= centroMinZ && proximoZ <= centroMaxZ))
        {
            Vector3 mover = new Vector3(0f, 0f, movimentoVertical);
            transform.Translate(mover * velocidade * Time.deltaTime);
        }
    }
}
