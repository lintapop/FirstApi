using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace FirstApi.Utils
{
    public class JwtAuthUtil
    {
        public string GenerateToken(string userGuid, string userEmail, string userAuth)
        {
            string secret = "Artion";//加解密的key,如果不一樣會無法成功解密 ,安全金鑰
            Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
            claim.Add("userId", userGuid);
            claim.Add("userEmail", userEmail);
            claim.Add("userAuth", userAuth);
            claim.Add("Exp", DateTime.Now.AddDays(1));//Token 時效設定100秒 default-no need to change this
            var payload = claim;

            //token 生成的地方
            var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
            return token;
        }
    }
}