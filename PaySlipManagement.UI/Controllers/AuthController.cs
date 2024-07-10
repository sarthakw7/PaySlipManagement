using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NPOI.SS.Formula.Functions;
using NuGet.Common;
using PaySlipManagement.Common.Models;
using PaySlipManagement.UI.Common;
using PaySlipManagement.UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;
using PaySlipManagement.UI.Models.DTO;
using NuGet.Protocol;
using Microsoft.Extensions.Options;

namespace PaySlipManagement.UI.Controllers
{
    public class AuthController : Controller
    {
        private APIServices _apiServices;
        private readonly ApiSettings _apiSettings;
        public AuthController(APIServices apiServices, IOptions<ApiSettings> apiSettings)
        {
            this._apiServices = apiServices;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users();
                user.Emp_Code = model.Emp_Code;
                user.Password = model.Password;
                user.Role = "";

                // Make a POST request to the Web API
                var response = await _apiServices.PostAsync($"{_apiSettings.UserEndpoint}/Login", user); 
                if (!string.IsNullOrEmpty(response))
                {
                    // Handle a successful login
                    ViewBag.Emp_Code = model.Emp_Code.ToString();

                    // Deserialize the JSON response to extract the token

                    var jsonresponse = JsonConvert.DeserializeObject<ApiResponse>(response);

                    var token = jsonresponse.Token;

                    // Store the token in a cookie
                    Response.Cookies.Append("AuthToken", token, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });

                    // Store the token in a cookie
                    Response.Cookies.Append("empCode",jsonresponse.User.EmpCode , new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict
                    });

                    // Get the claims from the token
                    var claimsPrincipal = GetClaimsPrincipalFromToken(token);
                    var roleClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                    if(roleClaim != null)
                    {
                        var role = roleClaim.Value;
                        if (role == "Admin")
                        {
                            return RedirectToAction("AdminView", "Auth");
                        }
                        else if (role == "Employee")
                        {
                            return RedirectToAction("GeneratePdf", "Employee");
                        }
                    }
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    // Handle the case where the API request fails or login is unsuccessful
                    ModelState.AddModelError(string.Empty, "API request failed or login was unsuccessful");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return View(model);
        }
        [HttpGet]
        public IActionResult AdminView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Employee()
        {
            return View();
        }

        private ClaimsPrincipal GetClaimsPrincipalFromToken(string token)

        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("your_secret_key_here_1234567890_1234567890_1234567890_");

            var tokenValidationParameters = new TokenValidationParameters

            {

                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new SymmetricSecurityKey(key),

                ValidateIssuer = false,

                ValidateAudience = false

            };

            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            return principal;

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        //[HttpGet]
        //public async Task<IActionResult> EmployeeDetails()
        //{
        //    var token = HttpContext.Session.GetString("JWTToken"); // Retrieve token from session or secure storage

        //    var client = _apiServices.CreateClient();
        //    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        //    var apiEndpoint = "/api/Employee/GetEmployeeById"; // Replace with your API endpoint
        //    var response = await client.GetAsync(apiEndpoint);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var employee = await response.Content.ReadAsAsync<Employee>(); // Replace with your EmployeeDetails model
        //        return View(employee);
        //    }
        //    else
        //    {
        //        // Handle API call failure
        //        return RedirectToAction("Index", "Home"); // Redirect to home or error page
        //    }
        //}


        //public async Task<IActionResult> UserDetails()
        //{
        //    var empCode = User.Identity.Name;
        //    var client = _apiServices.CreateClient();
        //    /* var apiBaseUrl = _apiServices["AppSettings:ApiBaseUrl"];*/ 
        //    var apiEndpoint = $"{_apiServices}/api/employee/details/{empCode}"; 

        //    var response = await client.GetAsync(apiEndpoint);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var employee = await response.Content.ReadAsAsync<EmployeeDetails>(); // Replace with your EmployeeDetails model
        //        return View(employee);
        //    }
        //    else
        //    {
        //        // Handle API call failure
        //        return RedirectToAction("Index", "Home"); // Redirect to home or error page
        //    }
        //}


    }
}
