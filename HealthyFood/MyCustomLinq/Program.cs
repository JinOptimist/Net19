
using MyCustomLinq;
using MyCustomLinq.Models;
using System.Linq;

var users = new UserGenerator().BuildRandomUsers();



var adultUsers = users.Where(x => x.IsAdult);


var ages = users.MySelect(user => user.Age);

Console.WriteLine(string.Join('\n', ages));


var listBankAccounts = new List<BankAccount>();

MyLinq.MyWhere(listBankAccounts, x => x.IsActive);
