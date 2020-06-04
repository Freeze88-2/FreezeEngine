using System.Collections.Generic;

namespace FreezeEngine
{
    public class PhysicsUpdate
    {
        private readonly List<PhysicsObject> components = new List<PhysicsObject>();

        public PhysicsUpdate(List<IGameObject> gameObjects)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                for (int b = 0; b < gameObjects[i].Components.Count; b++)
                {
                    if (gameObjects[i].Components[b] is PhysicsObject)
                    {
                        components.Add(gameObjects[i].Components[b] as PhysicsObject);
                    }
                }
            }
        }

        public void UpdatePhysics()
        {
            for (int i = 0; i < components.Count; i++)
            {
                if (components.Exists(c => c.ColliderPos == components[i].ColliderPos && c != components[i]))
                {
                    components[i].ResetPosOnCollision();
                }
            }
            for (int i = 0; i < components.Count; i++)
            {
                components[i].UpdateComponent();
            }
        }
    }
}