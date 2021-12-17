using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TeamMe
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class FrogControls : MonoBehaviour
    {
        public float moveSpeed;
        public float jumpSpeed;
        public float timeBeforeWin;
        
        private Rigidbody2D _rb;
        private Animator anim;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Object 1"))
            {
                MinigameManager.Instance.minigame.gameWin = false;
                StopAllCoroutines();
                Destroy(gameObject);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            StartCoroutine(DelayWin());
        }
        
        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontal * moveSpeed, _rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                movement.y = jumpSpeed;
            }
            
            _rb.velocity = movement;
            
            anim.SetFloat("vSpeed", _rb.velocity.y);
        }

        private IEnumerator DelayWin()
        {
            yield return new WaitForSeconds(timeBeforeWin);
            MinigameManager.Instance.minigame.gameWin = true;
        }
    }
}