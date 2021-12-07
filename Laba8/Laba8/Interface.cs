namespace Laba8
{
    public interface Iarv<T>
    {
        public void Add(T obj);
        public void Remove(T obj);
        public void View();

        public void WriteFile();
        public void ReadFile();
    }
}
