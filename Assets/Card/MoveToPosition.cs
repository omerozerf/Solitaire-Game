using System;
using UnityEngine;

namespace _Scripts
{
    public class MoveToPosition : MonoBehaviour
    {
        [SerializeField] private float speed = 100f;
        
        private Vector3 targetPos;
        private float distanceFactor;


        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed * distanceFactor);
        }


        public void SetTargetPos(Vector3 position)
        {
            targetPos = position;
            
            var distance = Vector3.Distance(transform.position, position);

            if (distance == 0f)
            {
                distanceFactor = 1;
                return;
            }

            distanceFactor = 1f / distance;
        }
    }
}