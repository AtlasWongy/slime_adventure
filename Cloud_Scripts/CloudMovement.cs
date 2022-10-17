using Godot;
using System;

public class CloudMovement : Node2D
{
    private SceneTreeTween TW;
    public override void _EnterTree()
    {
        TW = CreateTween();
        var cloud = GetNode(".");
        TW.TweenProperty(cloud, "position:x", RandomVerticalNumGen(), RandomTimeNumGen());
    }

    private float RandomVerticalNumGen() {
        return (float)GD.RandRange(-1000f, -1500f);
    }

    private float RandomTimeNumGen() {
        return (float)GD.RandRange(10.0f, 20.0f);
    }
}
