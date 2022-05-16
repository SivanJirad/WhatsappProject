using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebWhatsappApi;
using WebWhatsappApi.Service;


namespace WebWhatsapp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        UsersService usersService = new UsersService();

        //[Authorize]
        [HttpGet(Name = "GetUser")]
        public IEnumerable<User> Get()
        {
            var list = usersService.getAllUsers();
            return list.ToList();

        }

        //public IActionResult Get()
        //{
        //    var list = usersService.getAllUsers();
        //    Ok(list.ToList().Select(e => new { id = e.UserName, }));

        //}


        public class UserLogin
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }


        [HttpPost(Name = "LoginUser")]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(UserLogin user)
        {
            Boolean singed = false;
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    User myUser = usersService.checkIfInDB(user.UserName, user.Password);
                    if (myUser != null)
                    {
                        SignIn(myUser);
                        singed = true;
                    }
       
                }
            }
            return Ok(singed);
        }






        //public void Logout()
        //{
        //    HttpContext.SignOutAsync();
        //}


        [HttpPost(Name = "RegisterUser")]
        //[ValidateAntiForgeryToken]
        public void Register(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    usersService.addUser(user);
                    SignIn(user);
                }
            }
        }


        private async void SignIn(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties { };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }



        //private readonly  _context;

        //public UsersController(WebWhatsappApiContext context)
        //{
        //    _context = context;
        //}

        // GET: Users
        //public async Task<IActionResult> Index()
        //{
        //      return _context.Movie != null ? 
        //                  View(await _context.Movie.ToListAsync()) :
        //                  Problem("Entity set 'WebWhatsappApiContext.User'  is null.");
        //}

        // GET: Users/Details/5
        //public async Task<IActionResult> Details(string id)
        //{
        //    if (id == null || _context.User == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.User
        //        .FirstOrDefaultAsync(m => m.UserName == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// GET: Users/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Users/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserName,Password,NickName,Image")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(user);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Edit/5
        //public async Task<IActionResult> Edit(string id)
        //{
        //    if (id == null || _context.User == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.User.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(user);
        //}

        //// POST: Users/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(string id, [Bind("UserName,Password,NickName,Image")] User user)
        //{
        //    if (id != user.UserName)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(user);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserExists(user.UserName))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(user);
        //}

        //// GET: Users/Delete/5
        //public async Task<IActionResult> Delete(string id)
        //{
        //    if (id == null || _context.User == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _context.User
        //        .FirstOrDefaultAsync(m => m.UserName == id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(user);
        //}

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    if (_context.User == null)
        //    {
        //        return Problem("Entity set 'WebWhatsappApiContext.User'  is null.");
        //    }
        //    var user = await _context.User.FindAsync(id);
        //    if (user != null)
        //    {
        //        _context.User.Remove(user);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserExists(string id)
        //{
        //    return (_context.User?.Any(e => e.UserName == id)).GetValueOrDefault();
        //}
    }
}
