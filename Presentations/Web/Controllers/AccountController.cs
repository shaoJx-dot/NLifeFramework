using Application.Domain;
using Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Component.Utils.Drawing;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Component.Web.Http;

namespace Web.Controllers
{
    public class AccountController : Controller
    {


        #region 属性
        private IAuthenticationManager AuthenticationManager { get { return HttpContext.GetOwinContext().Authentication; } }
        #endregion


        private readonly UsersService _UsersService;

        public AccountController(UsersService usersService)
        {
            ViewBag.MenuClassDictionary = NavigationService.GetCurrent(11);
            _UsersService = usersService;
        }

        //
        // GET: /Member/User/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = _UsersService.Find(loginViewModel.UserName);
                if (_user == null) ModelState.AddModelError("UserName", "用户名不存在");
                //else if (_user.Password == Common.Security.Sha256(loginViewModel.Password))
                else if ( _user.Passwd == loginViewModel.Password )
                {
                    _user.LoginTime = System.DateTime.Now;
                    _user.LoginIP = Request.UserHostAddress;
                    _UsersService.Update(_user);

                    var _identity = CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginViewModel.RememberMe }, _identity);
                    //return RedirectToAction("Index", "Home");
                    if (string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
                        //Response.Redirect("/");
                        return Redirect("/");
                    else
                        return Redirect(loginViewModel.ReturnUrl);
                    //Response.Redirect(loginViewModel.ReturnUrl);
                }
                else ModelState.AddModelError("Password", "密码错误");
            }
            return View();
        }
        */

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var _user = _UsersService.Find(loginViewModel.UserName);
                if (_user == null) ModelState.AddModelError("UserName", "用户名不存在");
                else if (_user.Passwd != loginViewModel.Password) ModelState.AddModelError("Password", "密码不正确");
                else
                {
                    _user.LoginTime = System.DateTime.Now;
                    _user.LoginIP = Request.UserHostAddress;
                    _UsersService.Update(_user);

                    System.Web.HttpContext.Current.Session.Add("userID", _user.ID);
                    System.Web.HttpContext.Current.Session.Add("userName", _user.Name);
                    System.Web.HttpContext.Current.Session.Add("userDisplayName", _user.DisplayName);
                    int days = loginViewModel.RememberMe ? 365 : 0;
                    CookieHelper.AddCookie(_user.ID.ToString(), _user.Name, _user.DisplayName, days);
                    
                    if (string.IsNullOrWhiteSpace(loginViewModel.ReturnUrl))
                        //Response.Redirect("/");
                        return Redirect("/User");
                    else
                        return Redirect(loginViewModel.ReturnUrl);
                }
            }
            return View();
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            CookieHelper.RemoveCookie();
            System.Web.HttpContext.Current.Session.Remove("userID");
            System.Web.HttpContext.Current.Session.Remove("userName");
            System.Web.HttpContext.Current.Session.Remove("userDisplayName");
            return Redirect(Url.Content("~/"));

        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || register.VerificationCode == null
                || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {
                if (_UsersService.Exist(register.UserName)) ModelState.AddModelError("UserName", "用户名已存在");
                else
                {
                    Users _user = new Users()
                    {
                        Name = register.UserName,
                        //默认用户组代码写这里
                        //DisplayName = register.DisplayName,
                        DisplayName = register.UserName,
                        //Passwd = Security.Sha256(register.Password),
                        Passwd = register.Password,
                        //邮箱验证与邮箱唯一性问题
                        Email = register.Email,
                        //用户状态问题
                        Status = 0,
                        //RegistrationTime = System.DateTime.Now
                    };
                    _user = _UsersService.Add(_user);
                    if (_user.ID > 0)
                    {
                        //return Content("注册成功！");
                        //var _identity = CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                        //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        //AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, _identity);
                        CookieHelper.AddCookie(_user.ID.ToString(), _user.Name, _user.DisplayName);
                        return RedirectToAction("Index", "User");
                    }
                    else { ModelState.AddModelError("", "注册失败！"); }
                }
            }
            return View(register);
        }

        /// <summary>
        /// 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerificationCode()
        {
            ValidateCoder validateCoder = new ValidateCoder();

            string verificationCode = validateCoder.GetCode(6);
            System.Drawing.Bitmap _img = validateCoder.CreateImage(verificationCode, ValidateCodeType.NumberAndLetter);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }

        public ClaimsIdentity CreateIdentity(Users user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            //_identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.DisplayName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.DisplayName));
            return _identity;
        }

        
    }
}