using SFML.Graphics;
using SFML.System;


abstract class GameObject
{
    private Level? _level;
    public Level OwningLevel{
        private get {
            if(_level is null)    
                throw new Exception("Null owning level");
            return _level;
        }
        set{
            _level = value ?? throw new Exception("Null owning level");
        }
    }
    public Vector2f Position = new Vector2f(0.0f, 0.0f);
    public float Rotation;
    public readonly List<Shape> Shapes = new List<Shape>();

    public abstract void Update(float dt);

    public void Spawn(GameObject obj){
        OwningLevel.SpawnObject(obj, Position);
    }

    public void Destroy(){
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