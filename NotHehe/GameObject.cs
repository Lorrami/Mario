using SFML.Graphics;
using SFML.System;


abstract class GameObject
{
    public Level? OwningLevel{private get; set;}
    public Vector2f Position = new Vector2f(0.0f, 0.0f);
    public float Rotation;
    public readonly List<Shape> Shapes = new List<Shape>();

    public abstract void Update(float dt);

    public void Spawn(GameObject obj){
        if(OwningLevel is null)
            throw new Exception("Null owning level");
        
        OwningLevel.SpawnObject(obj, Position);
    }

    public void Destroy(){
        if(OwningLevel is null)
            throw new Exception("Null owning level");

        OwningLevel.DestroyObject(this);
    }

    public void AddComponent(Shape shape)
    {
        Shapes.Add(shape);
    }

    public Transform Transform
    {
        get
        {
            Transformable transformable = new Transformable();
            transformable.Position = Position;
            transformable.Rotation = Rotation;
            return transformable.Transform;
        }
    }
}