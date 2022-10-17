using Godot;
using System;

public class Player_Controller : KinematicBody2D
{
    private Vector2 motion;
    private AnimatedSprite animatedSprite;
    private float X;
    private bool facingRight = true;

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite>("./Inner/AnimatedSprite");
    }

    public override void _PhysicsProcess(float delta)
    {
        Gravity();
        Walking();
        FlipTheSprite();
        Jumping();
        motion = MoveAndSlide(motion, new Vector2(0, Player_Physics_Constants.UP), true);
    }

    private void Walking() {
        
        X = Input.GetAxis("key_left", "key_right");

        if (X != 0) {
            motion.x += X * Player_Physics_Constants.ACCELERATION;
            motion.x = Mathf.Clamp(motion.x, -Player_Physics_Constants.MOVESPEED, Player_Physics_Constants.MOVESPEED);
        }
        else {
            motion.x = Mathf.Lerp(motion.x, 0, 0.2f);
        } 

        if (X == 0) {
            animatedSprite.Play("Idle");
        } 
        else if (X != 0) {
            animatedSprite.Play("Walk");
        }
        
    }

    private void Gravity() {
        motion.y += Player_Physics_Constants.GRAVITY;
        if (motion.y > Player_Physics_Constants.MAXFALLSPEED) {
            motion.y = Player_Physics_Constants.MAXFALLSPEED;
        }
    }

    private void Jumping() {
        if (IsOnFloor() && Input.IsActionPressed("key_jump")) {
            motion.y = - Player_Physics_Constants.JUMPFORCE;
        }
    }

    private void FlipTheSprite() {
        if (!facingRight && X > 0) {
            facingRight = true;
            Node2D inner = GetNode<Node2D>("./Inner");
            inner.Scale = new Vector2(-1 * inner.Scale.x, inner.Scale.y);
        }
        else if (facingRight && X < 0) {
            facingRight = false;
            Node2D inner = GetNode<Node2D>("./Inner");
            inner.Scale = new Vector2(-1 * inner.Scale.x, inner.Scale.y);
        }
    }
}
