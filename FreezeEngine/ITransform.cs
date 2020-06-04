namespace FreezeEngine
{
    public interface ITransform
    {
        public abstract Vector3 Position { get; set; }
        public abstract Vector3 Rotation { get; set; }
    }
}