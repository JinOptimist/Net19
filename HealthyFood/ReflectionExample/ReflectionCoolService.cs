using System.Reflection;

namespace ReflectionExample
{
    public class ReflectionCoolService
    {
        public void ReadTypeInof(object obj)
        {
            var type = obj.GetType();
            Console.WriteLine(type.Name);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                Console.WriteLine($"\t{field.Name}");
            }

            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var method in methods)
            {
                Console.WriteLine($"\tMethod: {method.Name}");
            }

        }

        public void UpdateSecretValue(UserViewModel model)
        {
            var type = model.GetType();
            var field = type.GetField("SecretField", BindingFlags.Instance | BindingFlags.NonPublic);

            field.SetValue(model, "Test");
        }

        public UserDataModel Convert(UserViewModel user)
        {
            var dbUser = new UserDataModel();
            dbUser.Id = user.Id;
            dbUser.Name = user.Name;
            dbUser.Email = user.Email;
            return dbUser;
        }

        public TypeToDbModel ConvertFromViewModelToDbModel<TypeFromViewModel, TypeToDbModel>(TypeFromViewModel viewModel)
            where TypeToDbModel : new()
        {
            var dbModelType = typeof(TypeToDbModel);
            var dbUser = new TypeToDbModel();
            var viewModelType = viewModel.GetType();
            //var viewModelType = typeof(UserViewModel);

            var viewModelProperties = viewModelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var viewModelProperty in viewModelProperties)
            {
                var viewModelPropertyValue = viewModelProperty.GetValue(viewModel);
                Console.WriteLine($"{viewModelProperty.Name}: {viewModelPropertyValue}");
                var dbProperty = dbModelType.GetProperty(viewModelProperty.Name);
                if (dbProperty != null)
                {
                    dbProperty.SetValue(dbUser, viewModelPropertyValue);
                }
                else
                {
                    //ignore or 
                    //throw new Exception($"Not enought property: {viewModelProperty.Name}");
                }
            }

            return dbUser;
        }
    }
}
