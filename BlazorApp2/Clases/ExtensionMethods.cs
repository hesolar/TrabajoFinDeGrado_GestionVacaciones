namespace System;
public static class ExtensionMethods {

    public static UsuarioResponse GetCurrentUser(this AuthenticationStateProvider authenticationStateProvider, API api) { 
        var authState =  authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.Result.User.Identity.Name;
        var usuario =  api.GetUsuarioByCorreoEmpresaAsync(userIdentity).Result;
        return usuario;
    }
}
