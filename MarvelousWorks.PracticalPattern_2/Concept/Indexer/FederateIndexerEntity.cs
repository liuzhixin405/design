namespace MarvellousWorks.PracticalPattern.Concept.Indexer
{
    public enum Gender { Male, Female }

    // ÁªºÏË÷Òı = Name, Age
    public struct User
    {
        private string name;
        private int age;
        private Gender gender;

        public User(string name, int age, Gender gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }

        public string Name { get { return name; } }
        public int Age { get { return age; } }
        public Gender Gender { get { return gender; } }

        public int Key { get { return (name + age).GetHashCode(); } }
    }
}
