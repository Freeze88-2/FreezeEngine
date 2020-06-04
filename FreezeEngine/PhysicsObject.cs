namespace FreezeEngine
{
    public class PhysicsObject : IComponent
    {
        private readonly GameObject self;
        public int XDim { get; }
        public int Ydim { get; }
        public Vector3 ColliderPos => self.Position;
        public Vector3 OldPos { get; private set; }

        public PhysicsObject(int x, int y, GameObject self)
        {
            XDim = x;
            Ydim = y;
            OldPos = self.Position;
            this.self = self;
        }

        public void UpdateComponent()
        {
            OldPos = self.Position;
        }

        public void ResetPosOnCollision()
        {
            self.Position = OldPos;
        }
    }
}