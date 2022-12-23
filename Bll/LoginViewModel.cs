using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RestSharp;

namespace Bll;
public class LoginViewModel: ReactiveObject
{
    [Reactive] public string Login { get; set; }
    [Reactive] public string Password { get; set; }
    [Reactive] public string Status { get; set;}
    public ReactiveCommand<Unit, bool> LoginCommand { get; }

    protected IAuthClient authClient;

    public LoginViewModel(IAuthClient authClient)
    {
        this.authClient = authClient;

        LoginCommand = ReactiveCommand.CreateFromTask(async () => await authClient.LoginAsync(Login, Password) != null);

        LoginCommand.Subscribe(result =>
        {
            Status = result ? "" : "Incorrect login or password...";
        });

        LoginCommand.ThrownExceptions.Subscribe(exc =>
        {
            Status = "Something went wrong...";
        });
    }
}
