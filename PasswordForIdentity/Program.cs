using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

var options = new PasswordHasherOptions();
options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;

var fakeUser = new IdentityUser();
var hasher = new PasswordHasher<IdentityUser>();

Console.WriteLine("----------- IDENTITY PASSWORD -------------");

string? userPassword = "";
int count = 0;
bool retry;

do
{
	while (userPassword is null || string.IsNullOrEmpty(userPassword) || userPassword.Length < 8)
	{
		if (count == 0)
			Console.WriteLine("Merci d'entrer le mot de passe, il sera haché (8 caractères min) : ");

		if (count > 0)
			Console.WriteLine("Votre mot de passe est vide ou ne comporte pas 8 caractères, merci de réessayer : ");

		userPassword = Console.ReadLine();
		count++;
	}
	var hashPassword = hasher.HashPassword(fakeUser, userPassword);

	Console.WriteLine("\n--------------------------------------");
	Console.WriteLine("Votre mot de passe haché pour script SQL : " + hashPassword);
	Console.WriteLine("--------------------------------------\n");

	Console.Write("Voulez vous hash un nouveau mot de passe ? (y/n) : ");
	string? read = Console.ReadLine();

	if (read is null || read.ToLower() != "y")
	{
		retry = false;
	}
	else
	{
		retry = true;
		userPassword = null;
		count = 0;
	}

} while (retry);





