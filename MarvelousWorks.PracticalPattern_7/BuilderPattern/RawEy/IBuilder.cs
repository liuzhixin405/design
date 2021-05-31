namespace MarvellousWorks.PracticalPattern.BuilderPattern.RawEy
{
    public class House
    {
        public void AddWindowAndDoor() { }
        public void AddWallAndFloor() { }
        public void AddCeiling() { }
    }

    public class Car
    {
        public void AddWheel() { }
        public void AddEngine() { }
        public void AddBody() { }
    }

    public interface IBuilder
    {
        void BuildPart1();
        void BuildPart2();
        void BuildPart3();
    }

    public class CarBuilder : IBuilder
    {
        private Car car;
        public void BuildPart1() { car.AddEngine(); }
        public void BuildPart2() { car.AddWheel(); }
        public void BuildPart3() { car.AddBody(); }
        public Car GetResult() { return car; }
    }
    public class HouseBuilder : IBuilder
    {
        private House house;
        public void BuildPart1() { house.AddWallAndFloor(); }
        public void BuildPart2() { house.AddWindowAndDoor(); }
        public void BuildPart3() { house.AddCeiling(); }
        public House GetResult() { return house; }
    }

    public class Director
    {
        public void Construct(IBuilder builder) //指导IBuilder的创建过程
        {
            builder.BuildPart1();
            builder.BuildPart2();
            builder.BuildPart3();
        }
    }
}
