using SFML.Graphics;
using SFML.System;


abstract class GameObject: GraphicsBody
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
    public abstract void Update(float dt);

    public void Spawn(GameObject obj){
        OwningLevel.SpawnObject(obj, Position);
    }

    public void Destroy(){
        OwningLevel.DestroyObject(this);
    }

}