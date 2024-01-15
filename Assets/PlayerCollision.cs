
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
  
   
void OnCollisionEnter (Collision collisionInfo){
   if(collisionInfo.collider.tag=="Obstacle"){

  Debug.Log("HIt");
  Destroy(GameObject.FindWithTag("Obstacle"));

   }
}
}
