using MyCustomLinq.Models;

namespace MyCustomLinq
{
    public static class MyLinq
    {
        // VERY BAD!!!!!!!!!!!!
        //public static int Name;

        public static List<MyType> MyWhere<MyType>(this List<MyType> models, Func<MyType, bool> conditionOfGoodModel)
        {
            var answer = new List<MyType>();

            foreach (var mmodel in models)
            {
                if (conditionOfGoodModel(mmodel))
                {
                    answer.Add(mmodel);
                }
            }

            return answer;
        }

        public static IEnumerable<OutType> MySelect<InType, OutType>(this List<InType> models, Func<InType, OutType> conditionOfGoodModel)
        {
            foreach (var model in models)
            {
                yield return conditionOfGoodModel(model);
            }
        }

        //public List<User> WhereAdult(List<User> users)
        //{
        //    var answer = new List<User>();

        //    foreach (var user in users)
        //    {
        //        if (user.IsAdult)
        //        {
        //            answer.Add(user);
        //        }
        //    }

        //    return answer;
        //}

        //public List<User> MyWhere(List<User> users, Func<User, bool> conditionOfGoodUser)
        //{
        //    var answer = new List<User>();

        //    foreach (var user in users)
        //    {
        //        if (conditionOfGoodUser(user))
        //        {
        //            answer.Add(user);
        //        }
        //    }

        //    return answer;
        //}

        //public List<BankAccount> MyWhere(List<BankAccount> users, Func<BankAccount, bool> conditionOfGoodUser)
        //{
        //    var answer = new List<BankAccount>();

        //    foreach (var user in users)
        //    {
        //        if (conditionOfGoodUser(user))
        //        {
        //            answer.Add(user);
        //        }
        //    }

        //    return answer;
        //}


    }
}
