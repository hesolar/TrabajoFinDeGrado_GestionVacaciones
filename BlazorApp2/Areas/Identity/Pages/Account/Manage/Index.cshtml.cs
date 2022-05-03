// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlazorApp2.Areas.Identity.Pages.Account.Manage;
public class IndexModel : PageModel {
    private AuthenticationStateProvider _authenticationStateProvider;
    private API _api;
    public UsuarioResponse UsuarioAplicacion;

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public IndexModel(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        API api) {
        _userManager = userManager;
        _signInManager = signInManager;
        _api = api;
        
    }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public string EmailCorporativo { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [TempData]
    public string StatusMessage { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [BindProperty]
    public InputModel Input { get; set; }

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class InputModel {
        ///// <summary>
        /////     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        /////     directly from your code. This API may change or be removed in future releases.
        ///// </summary>
        //[Phone]
        //[Display(Name = "Phone number")]
        //public string PhoneNumber { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]

        public String Apellido1 { get; set;}
        [Required]

        public String Apellido2 { get; set;}

        public String NIF { get; set;}
        [Phone]
        public string Telefono1 { get; set; }
        [Phone]
        public string Telefono2 { get; set; }

    }

    private async Task LoadAsync(IdentityUser user) {
        var userName = await _userManager.GetUserNameAsync(user);
        var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        UsuarioAplicacion = await _api.GetUsuarioByCorreoEmpresaAsync(userName);
        EmailCorporativo = userName;
        this.Input  = MapFrom<UsuarioResponse, InputModel>.Map(UsuarioAplicacion);

    }

    public async Task<IActionResult> OnGetAsync() {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        await LoadAsync(user);
        return Page();
    }

    public async Task<IActionResult> OnPostAsync() {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        if (!ModelState.IsValid) {
            await LoadAsync(user);
            return Page();
        }


        await ActualizarUsuarioAPlicacion(user.Email);
        await _signInManager.RefreshSignInAsync(user);
        StatusMessage = "Your profile has been updated";
        return RedirectToPage();
    }



    public async Task ActualizarUsuarioAPlicacion(String correo) {

        UsuarioAplicacion = await _api.GetUsuarioByCorreoEmpresaAsync(correo);

        UpdateUsuarioCommand command = MapFrom<InputModel, UpdateUsuarioCommand>.Map(Input);
        command.IdTecnico = UsuarioAplicacion.IdTecnico;

        await _api.UpdateUsuarioAsync(command);


    }
}

