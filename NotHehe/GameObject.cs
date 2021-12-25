using SFML.Graphics;
using SFML.System;


abstract class GameObject{
    public Level? OwningLevel{private get; set;}
    public Vector2f Position = new Vector2f(0, 0);

    public abstract void Update(float dt);

    public abstract void Render(RenderWindow window);

    public void Spawn(GameObject obj){
        if(OwningLevel is null)
            throw new Exception("Null owning level");
        
        OwningLevel.SpawnObject(obj);
    }
}