namespace ReflectionExample
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        private string EmailSecret { get; set; }

        public string GetEmailSecret() { return EmailSecret; }

        private readonly string SecretField = "password";

        public void Test()
        {
            Id = 1;
        }

        public int GetNameLength()
        {
            if (Name == SecretField)
            {
                return 0;
            }

            return Name.Length;
        }
   

    }
}
