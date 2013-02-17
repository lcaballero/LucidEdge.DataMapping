# LucidEdge.DataMapping

## Overview 

This library consists of code that provides some assistance when hand-wrting
ORM.  The current release focuses only on the PostGres DB, and doesn't attempt
to handle concurrency or asynchronicity.  The hope is that later version will
use `TaskResult` or something similar.

## Getting Started

To build the project open the .sln in the Tests project, which will bring
in both the core librar, and Samples library.  Build the project and
do what you will with the resulting .dlls.  

## Example

The code below is an example of a class which can be injected with a map, and
can thus map the underlying dictionary to a strongly typed interface, that
can remap the names of columns to something more appropriate, or
something that matches the language style, or something more explicit.

```CSharp
public class UserProfile : IDataMapping
{
	public IDictionary<string, DataPoint> Map { get; set; }
	
	public long? Id { get { return Map["Id"].ToValue<long?>(); } }
	public int? Version { get { return Map["Version"].ToValue<int?>(); } }
	public DateTime? Created_At { get { return Map["Created_At"].ToValue<DateTime?>(); } }
	public DateTime? Updated_On { get { return Map["Updated_On"].ToValue<DateTime?>(); } }
	public bool IsActive { get { return Map["IsActive"].ToValue<bool>(); } }
	public bool IsLocked { get { return Map["IsLocked"].ToValue<bool>(); } }

	public string UserName { get { return Map["UserName"].ToValue<string>(); } }
	public string Password { get { return Map["Password"].ToValue<string>(); } }
	public int? UserGroup_Id { get { return Map["UserGroup_Id"].ToValue<int?>(); } }

	public string Phone { get; set; }
	public string Email { get; set; }
}
```

The only requirement is that this class implements IDataMapping.
With IDataMapping a number of functions that simply produce Dictionaries
can be used to provide an instance with the underlying data.

The library comes with a few helpful extension functions for creating
these backing Dictionaries, and the following example which is
pulled from `Test_IDataMapping_Lookup` is an example use of `.Add(...)`
and `.ToDataMapping<T>()`.

```CSharp
var dps =
	new List<DataPoint>()
		.Add("id", id)
		.Add("version", version)
		.Add("created_at", created_at)
		.Add("updated_on", updated_on)
		.Add("isactive", true)
		.Add("islocked", true)
		.Add("usergroup_id", group_id)
		.Add("password", "password")
		.Add("username", "username")
		.ToDataMapping<UserProfile>();
```

## The DataBase

With the above code ready to run, we now can consider a data source,
and any data source that can be mapped to the `IDataMapping` interface
will do.

The helper methods found in `LucidEdge.DataMapping.Requests` were
designed with the idea that the underlying data would eventually
be injected into instances of `IDataMapping`.

`Requests` currently runs the function `Insert`, `Read`, `Create`, and
`DropTable` in a synchronous fashion.  (Later versions of this library
may come to use either concurrency or asynchronocity).

With these function in hand we can use them like this:

`UserScripts.Read_All_Users` is nothing more than a Sql Script embedded
in the dll as a Resource.  The empty data points are provided since
there are no required parameters, but if the script needed paramters
they could be passed as DataPoint instances.

```CSharp
	UserScripts.Read_All_Users.Read<User>(
		new List<DataPoint>());
```

In truth, Read<T> uses an optional paramter for both the parameters
and the connection, which means the above code could have been made
even simpler:

```CSharp
	UserScripts.Read_All_Users.Read<User>();
```

`Insert` most definitely requires paramters, but it too is simple:

```CSharp
var dps = new List<DataPoint>()
	.Add("id", Rand.Next())
	.Add("version", Rand.Next())
	.Add("created_at", DateTime.Now)
	.Add("updated_on", DateTime.Now)
	.Add("isactive", true)
	.Add("islocked", true)
	.Add("usergroup_id", Rand.Next())
	.Add("password", "w4llst")
	.Add("username", "lucas.caballero");

UserScripts.Insert_User.Insert(dps);
```

# License

LucidEdge.DataMapping subnamespaces and the projects in those subnamespaces
are released under the MIT License.

Copyright 2013

Read the license here: http://opensource.org/licenses/MIT

Date: 2013-2-17
