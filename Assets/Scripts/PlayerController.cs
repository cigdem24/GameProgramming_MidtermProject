using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string axisName = "Horizontal";
    public float moveSpeed =15;
    public Rigidbody2D bombPrefab;
    public Transform bombSpawn;
    public Transform player;

    public void FixedUpdate()
    {
        BombaAt();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);
            bomb.AddForce(new Vector2(0, 1) * 1000);
        }
    }


    public void BombaAt()
    {
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);
    }
   

}
