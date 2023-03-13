
using MyCustomLinq;
using MyCustomLinq.Models;
using System.Linq;

var builder = new UserGenerator();
var usersMan = builder.BuildRandomUsers();

var sortedUserByName = usersMan
    .OrderBy(x => x.Name)
    .ThenBy(x => x.Age)
    .ThenBy(x => x.Height);

