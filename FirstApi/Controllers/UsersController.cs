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
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FirstApi.Models;
using FirstApi.Utils;

namespace FirstApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UsersController : ApiController
    {
        private readonly DBContext db = new DBContext();

        [HttpGet]
        [JwtAuthFilter]
        [Route("GetPersonalDetail")]
        public IHttpActionResult GetUser(User user)
        {
            var result = db.Users.FirstOrDefault(x => x.Id == user.Id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.Id,
                user.Fullname,
                user.Phone,
                user.Email,
                user.Avatar,
                user.CreatedAt,
                user.ArtistInfos,
                user.IsArtist,
            });
        }

        [HttpPut]
        [Route("UpdateInfo")]
        //public IHttpActionResult PutUser(int id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        [HttpPost]
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
                user.CreatedAt = DateTime.Now;
                user.GuId = Guid.NewGuid().ToString();

                db.Users.Add(user);
                db.SaveChanges();
                return Ok($"{user.Fullname}註冊成功");
            }
            else
            {
                return BadRequest("帳號已有人使用");
            }
        }

        [HttpPost]
        [Route("Login")]
        public IHttpActionResult PostLogin([FromBody] Login login)
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
            var token = jwtAuth.GenerateToken(user.GuId, user.Email, user.IsArtist.ToString());

            return Ok(new
            {
                user.GuId,
                user.Email,
                user.Fullname,
                user.IsArtist,
                user.Avatar,
                token
            });
        }

        //只要ｔｏｋｅｎ拿掉　就是登出哩　所以後端不寫ｌｏｇＯｕｔ
        //[HttpDelete]
        //[Route("LogOut")]  //attribute routing
        ////[ResponseType(typeof(User))]
        //public IHttpActionResult DeleteLogOut(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    db.SaveChanges();

        //    return Ok(user);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}