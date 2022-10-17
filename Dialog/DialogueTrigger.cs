using Godot;
using System;

public class DialogueTrigger : Area2D
{
    private bool canInteract = false;
    private string dialogResourcePath = "res://Scenes/Dialog/Dialog_Scenes.tscn";
    private PackedScene dialogScene;
    private Node dialogCollider;
    private Label label;
    private Dialog theDialog;

    public override void _Ready()
    {
        // Load the scene
        dialogScene = GD.Load<PackedScene>(dialogResourcePath);

        // Connect the signal
        dialogCollider = GetNode(".");
        dialogCollider.Connect("area_entered", this, nameof(this.OnAreaEntered));
        dialogCollider.Connect("area_exited", this, nameof(this.OnAreaExited));

        // Get the label reference
        label = GetNode<Label>("./Label");

    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsKeyPressed((int) KeyList.E) && canInteract) {
            label.Visible = false;
            theDialog = dialogScene.Instance<Dialog>();
            CallDeferred("add_child", theDialog);
        }
    }

    private void OnAreaEntered(Area2D area) {
        if (area.Name == "Area2D") {
            label.Visible = true;
            canInteract = true;
        }
    }

    private void OnAreaExited(Area2D area) {
        if (area.Name == "Area2D") {
            label.Visible = false;
            canInteract = false;
        }
    }
}
