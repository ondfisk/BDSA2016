namespace BDSA2016.Lecture04.Lib
{
    public class Character
    { 
        public int Id { get; set; }

        public string GivenName { get; set; }

        public string Surname { get; set; }

        public string Species { get; set; }
        
        public string Origin { get; set; }
        
        public int? Age { get; set; }

        public override string ToString() => $"{GivenName} {Surname} - a {Species} from {Origin}, age: {Age}";
    }
}