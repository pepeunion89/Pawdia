using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Range(1f, 5f)]
    [SerializeField] public float movementSpeed = 1.0f;
    [SerializeField] public Rigidbody2D player;
    private Animator animator;
    private int flagStart = 0;
    private Vector2 direction;



    public void HandleMovement(Vector2 movementDirection) {

        direction = movementDirection * movementSpeed;
        player.velocity = direction;

    }

    public void UpdateDirectionMovementAnimation(Vector2 direction, Transform boy) {

        if (flagStart == 0) {

            animator = boy.GetComponent<Animator>();

            flagStart = 1;
        }

        if (flagStart == 1) {
            if (direction.x == 0 && direction.y == 1) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (direction.x == 1 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == 0 && direction.y == -1) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == -1 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
            }

            if (Math.Truncate(direction.x * 10) == 7 && Math.Truncate(direction.y * 10) == 7) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (Math.Truncate(direction.x * 10) == -7 && Math.Truncate(direction.y * 10) == 7) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }

            if (Math.Truncate(direction.x * 10) == 7 && Math.Truncate(direction.y * 10) == -7) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (Math.Truncate(direction.x * 10) == -7 && Math.Truncate(direction.y * 10) == -7) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, true);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
            }

            if (direction.x == 0 && direction.y == 0) {
                animator.SetBool(Constants.PlayerConstants.IsWalkingUp, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingDown, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingLeft, false);
                animator.SetBool(Constants.PlayerConstants.IsWalkingRight, false);
            }
        }

    }
}
