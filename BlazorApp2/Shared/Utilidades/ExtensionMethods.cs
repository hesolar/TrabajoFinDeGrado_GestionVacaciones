namespace System;
public static class ExtensionMethods {
    /// <summary>
    /// Obtener el usuario de la aplicación
    /// </summary>
    /// <param name="authenticationStateProvider"></param>
    /// <param name="api"></param>
    /// <returns></returns>
    public static UsuarioResponse GetCurrentUser(this AuthenticationStateProvider authenticationStateProvider, API api) { 
        var authState =  authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.Result.User.Identity.Name;
        var usuario =  api.GetUsuarioByCorreoEmpresaAsync(userIdentity).Result;
        return usuario;
    }
}
