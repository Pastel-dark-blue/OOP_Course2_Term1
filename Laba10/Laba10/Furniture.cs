namespace Laba10
{
    class Furniture
    {
        //--> свойства мебели
        public string Name { get; set; }
        public int Price { get; set; }

        public Furniture(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + ", цена: " + Price;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is Furniture))
                return false;

            return (this.ToString() == obj.ToString());
        }

        public override int GetHashCode()
        {
            return (Price * Name.Length);
        }
    }
}
