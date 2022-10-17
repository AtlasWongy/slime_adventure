using Godot;
using System;

public class Dialog : Control
{
    private string[] dialog = {
        "Well hello there anemo",
        "Sorry but I am pretty stoned",
        "Hehehehehe"
    };

    private int dialogIndex = 0;
    private bool finishedTalking = false;
    private RichTextLabel richTextLabel;
    private Tween dialogTween;
    private AnimationPlayer animationPlayer;

    public override void _Ready()
    {
        // Dialog Tween reference here
        dialogTween = GetNode<Tween>("./DialogBox/Tween");
        dialogTween.Connect("tween_completed", this, nameof(this.OnTweenComplete));

        // Reference to the animation here
        animationPlayer = GetNode<AnimationPlayer>("./DialogBox/Indicator/AnimationPlayer");

        LoadTheDialog();
    }

    public override void _PhysicsProcess(float delta)
    {
        GetNode<Sprite>("./DialogBox/Indicator").Visible = finishedTalking;
        if (Input.IsActionJustPressed("ui_accept")) {
            LoadTheDialog();
        }
    }

    private void LoadTheDialog() {

        if (dialogIndex < dialog.Length) {
            finishedTalking = false;

            // Rich Text Label Reference here
            richTextLabel = GetNode<RichTextLabel>("./DialogBox/RichTextLabel");
            richTextLabel.BbcodeText = dialog[dialogIndex];
            richTextLabel.PercentVisible = 0;

            // Tween Functionality here
            dialogTween.InterpolateProperty(
                richTextLabel,
                "percent_visible",
                0,
                1,
                1,
                Tween.TransitionType.Linear,
                Tween.EaseType.InOut
            );
            dialogTween.Start();
        }
        else {
            QueueFree();
        }

        dialogIndex += 1;

    }

    private void OnTweenComplete(Godot.Object obj, NodePath key) {
        finishedTalking = true;
        animationPlayer.GetAnimation("IDLE").Loop = true;
        animationPlayer.Play("IDLE");
    }
}
