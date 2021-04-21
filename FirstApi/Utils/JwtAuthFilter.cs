using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace FirstApi.Utils
{
    //繼承 : ActionFilterAttribute 下方
    public class JwtAuthFilter : ActionFilterAttribute
    {
        private const string secret = "Artion";//加解密的key,如果不一樣會無法成功解密

        public static Dictionary<string, object> GetToken(string token)
        {
            return JWT.Decode<Dictionary<string, object>>(token, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
        }

        public static string GetTokenId(string token)
        {
            var tokenValue = JWT.Decode<Dictionary<string, object>>(token, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
            return tokenValue["userid"].ToString();
        }

        public static int GetTokenPermission(string token)
        {
            var tokenValue = JWT.Decode<Dictionary<string, object>>(token, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
            return (int)tokenValue["Permission"];
        }

        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            var request = actionContext.Request;//將當下request的動作
                                                //if (!WithoutVerifyToken(request.RequestUri.ToString()))
                                                //{
            if (request.Headers.Authorization == null || request.Headers.Authorization.Scheme != "Bearer")
            {
                var errorMessage = new HttpResponseMessage()
                {
                    ReasonPhrase = "Lost Token",
                    Content = new StringContent("code=5566")//自訂的錯誤訊息
                };
                //throw new HttpResponseException(errorMessage);
                //throw new System.Exception("Lost Token");
            }
            else
            {
                //怕有人惡搞Token進行try,catch 判斷
                try
                {
                    //解密後會回傳Json格式的物件(即加密前的資料)
                    var jwtObject = Jose.JWT.Decode<Dictionary<string, Object>>(
                        request.Headers.Authorization.Parameter,
                        Encoding.UTF8.GetBytes(secret),
                        JwsAlgorithm.HS512);

                    //時間檢查(是否過期)
                    if (IsTokenExpired(jwtObject["Exp"].ToString()))
                    {
                        var errorMessage = new HttpResponseMessage()
                        {
                            ReasonPhrase = "Token Expired",
                            Content = new StringContent("code=5566") //自訂的錯誤訊息
                        };
                        throw new HttpResponseException(errorMessage);
                    }
                    //throw new System.Exception("Token Expired");
                }
                catch (Exception e)
                {
                    var errorMessage = new HttpResponseMessage()
                    {
                        ReasonPhrase = "Loss Token",
                        Content = new StringContent($"code=5566,發生錯誤:{e}") //自訂的錯誤訊息
                    };
                    throw new HttpResponseException(errorMessage);
                }
            }
            //}
            base.OnActionExecuting(actionContext);
        }

        //Login不需要驗證因為還沒有token
        //需要全網頁驗證再使用,如果沒有,只需要針對需要驗證的部分下標籤驗證即可[JwtAuthFilter]
        //public bool WithoutVerifyToken(string requestUri)
        //{
        //    if (requestUri.EndsWith("/Login"))
        //        return true;
        //    return false;
        //}

        //驗證token時效
        public bool IsTokenExpired(string dateTime)
        {
            return Convert.ToDateTime(dateTime) < DateTime.Now;
        }
    }
}