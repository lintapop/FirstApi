using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using FirstApi.Models;
using FirstApi.Utils;

namespace FirstApi.Controllers
{
    public class UsersController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/Users1
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users1/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/User1/SignUp
        // 使用者登入

        [HttpPost]
        [ResponseType(typeof(User))]
        [Route("SignUp")]
        // 使用者註冊
        public IHttpActionResult PostSignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = db.Users.FirstOrDefault(x => x.Email == user.Email);
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.][a-zA-Z]{1,3}");
            Match match = regex.Match(user.Email);
            if (!match.Success)
            {
                return Ok("Email格式輸入錯誤!");
            }
            if (result == null)
            {
                user.PasswordSalt = Utils.salt.CreateSalt();
                user.Password = Utils.salt.GenerateHashWithSalt(user.Password, user.PasswordSalt);
                // user.CreatedAt = DateTime.Now;
                ////使用者權限(結帳按鈕後面所有頁面) 接前端 故留前端寫步道的東西
                //user.Avatar = "avatar.jpg";
                //user.Email = "artion@gmail.com";
                //user.Fullname = "darlin";
                //user.Phone = "0973647372";
                //user.IsArtist = true;

                db.Users.Add(user);
                db.SaveChanges();
                return Ok($"{user.Fullname}註冊成功");
            }
            else
            {
                return BadRequest("帳號已有人使用");
            }
        }

        // POST: api/Login
        //登入
        [HttpPost]
        [Route("Login")]
        //[ResponseType(typeof(user))]
        public IHttpActionResult Login([FromBody] Login login)
        {
            //確認輸入的Email是否正確
            var user = db.Users.FirstOrDefault(x => x.Email == login.Email);
            if (user == null)
                return Ok("登入失敗");

            //確認輸入的密碼是否正確
            string pwd = salt.GenerateHashWithSalt(login.Password, user.PasswordSalt);
            if (user.Password != pwd)
                return Ok("登入失敗");

            //生成token
            var jwtAuth = new JwtAuthUtil();
            var token = jwtAuth.GenerateToken(user.Id.ToString(), user.Email, user.Authority);

            return Ok(new
            {
                user.Id,
                user.Email,
                user.Fullname,
                user.Authority,
                user.Avatar,
                token
            });
        }

        // DELETE: api/Users1/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}