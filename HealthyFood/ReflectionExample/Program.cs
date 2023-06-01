using ReflectionExample;

Console.WriteLine("Hello, Reflection!");

var user = new UserViewModel()
{
    Name= "Test",
    Id = 9,
    Email = "test@tets.com"
};
var service = new ReflectionCoolService();

var dbuser = service.ConvertFromViewModelToDbModel<UserViewModel, UserDataModel>(user);

//var age = 123;

//service.ReadTypeInof(user);
//service.ReadTypeInof(age);


//user.Name= "Test";
//Console.WriteLine($"Name: {user.Name} L: {user.GetNameLength()}");

//user.Name = "password";
//Console.WriteLine($"Name: {user.Name} L: {user.GetNameLength()}");

//service.UpdateSecretValue(user);

//user.Name = "Test";
//Console.WriteLine($"Name: {user.Name} L: {user.GetNameLength()}");

//user.Name = "password";
//Console.WriteLine($"Name: {user.Name} L: {user.GetNameLength()}");
