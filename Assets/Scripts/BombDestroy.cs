using UnityEngine;

public enum Tag
{ 
   BOMBA
}
public class BombDestroy : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }

}
